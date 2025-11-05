using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskWise.Application.Common.Email;

namespace TaskWise.Infrastructure.Services.Email;

public sealed class EmailService : IEmailService
{
    private readonly EmailSettings _settings;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IOptions<EmailSettings> settings, ILogger<EmailService> logger)
    {
        _settings = settings.Value;
        _logger = logger;
    }

    public async Task<bool> SendEmailAsync(EmailMessage emailMessage, CancellationToken ct = default)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(_settings.SmtpHost))
            {
                _logger.LogWarning("SMTP host not configured. Email sending is disabled.");
                return false;
            }

            return await SendViaSmtpAsync(emailMessage, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {To}", emailMessage.To);
            return false;
        }
    }

    public async Task<bool> SendInviteEmailAsync(string recipientEmail, string recipientName, string inviteToken, string inviteUrl, CancellationToken ct = default)
    {
        // Construct invite URL if not provided
        string inviteUrlWithToken = string.IsNullOrWhiteSpace(inviteUrl)
            ? string.Format(_settings.InviteUrlTemplate, _settings.BaseUrl.TrimEnd('/'), inviteToken)
            : inviteUrl;

        var emailMessage = new EmailMessage
        {
            To = recipientEmail,
            ToName = recipientName,
            Subject = "You've been invited to join TaskWise",
            HtmlBody = EmailTemplates.GetInviteEmailHtml(recipientName, inviteUrlWithToken),
            PlainTextBody = EmailTemplates.GetInviteEmailPlainText(recipientName, inviteUrlWithToken),
            From = _settings.FromEmail,
            FromName = _settings.FromName
        };

        return await SendEmailAsync(emailMessage, ct);
    }

    private async Task<bool> SendViaSmtpAsync(EmailMessage emailMessage, CancellationToken ct)
    {
        using var client = new SmtpClient(_settings.SmtpHost, _settings.SmtpPort ?? 587);

        if (!string.IsNullOrWhiteSpace(_settings.SmtpUsername))
        {
            client.Credentials = new NetworkCredential(_settings.SmtpUsername, _settings.SmtpPassword);
        }

        client.EnableSsl = _settings.EnableSsl;

        using var message = new MailMessage
        {
            From = new MailAddress(emailMessage.From ?? _settings.FromEmail, emailMessage.FromName ?? _settings.FromName),
            Subject = emailMessage.Subject,
            IsBodyHtml = true
        };

        // Add HTML body
        if (!string.IsNullOrWhiteSpace(emailMessage.HtmlBody))
        {
            message.Body = emailMessage.HtmlBody;

            // Add plain text as alternate view if provided
            if (!string.IsNullOrWhiteSpace(emailMessage.PlainTextBody))
            {
                var plainTextView = AlternateView.CreateAlternateViewFromString(emailMessage.PlainTextBody, null, "text/plain");
                message.AlternateViews.Add(plainTextView);
            }
        }
        else if (!string.IsNullOrWhiteSpace(emailMessage.PlainTextBody))
        {
            message.Body = emailMessage.PlainTextBody;
            message.IsBodyHtml = false;
        }
        else
        {
            message.Body = string.Empty;
        }

        message.To.Add(new MailAddress(emailMessage.To, emailMessage.ToName));

        if (emailMessage.Cc?.Any() == true)
        {
            foreach (string cc in emailMessage.Cc)
            {
                message.CC.Add(new MailAddress(cc));
            }
        }

        if (emailMessage.Bcc?.Any() == true)
        {
            foreach (string bcc in emailMessage.Bcc)
            {
                message.Bcc.Add(new MailAddress(bcc));
            }
        }

        await client.SendMailAsync(message, ct);

        _logger.LogInformation("Email sent successfully via SMTP to {To}", emailMessage.To);
        return true;
    }
}

