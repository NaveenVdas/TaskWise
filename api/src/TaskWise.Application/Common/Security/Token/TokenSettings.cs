namespace TaskWise.Application.Common.Security.Token;

public sealed class TokenSettings
{
    public required string SecretKey { get; init; }
    public required string Audience { get; init; }
    public required string Issuer { get; init; }
    public required int ExpirationMinutes { get; init; }
}
