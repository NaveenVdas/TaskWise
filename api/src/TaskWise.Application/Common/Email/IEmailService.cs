namespace TaskWise.Application.Common.Email;

public interface IEmailService
{
    Task<bool> SendEmailAsync(EmailMessage emailMessage, CancellationToken ct = default);
    Task<bool> SendInviteEmailAsync(string recipientEmail, string recipientName, string inviteToken, string inviteUrl, CancellationToken ct = default);
}

