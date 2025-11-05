namespace TaskWise.Application.Common.Email;

public sealed class EmailSettings
{
    public required string FromEmail { get; init; }
    public required string FromName { get; init; }
    public string? SmtpHost { get; init; }
    public int? SmtpPort { get; init; }
    public string? SmtpUsername { get; init; }
    public string? SmtpPassword { get; init; }
    public bool EnableSsl { get; init; } = true;
    
    // Application URLs
    public required string BaseUrl { get; init; }
    public string InviteUrlTemplate { get; init; } = "{0}/auth/accept-invite?token={1}";
}

