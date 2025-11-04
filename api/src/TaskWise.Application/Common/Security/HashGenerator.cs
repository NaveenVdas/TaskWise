namespace TaskWise.Application.Common.Security;

public sealed class HashGenerator : IHashGenerator
{
    public string GenerateHash(string text) => BCrypt.Net.BCrypt.HashPassword(text);

    public bool VerifyHash(string text, string hashText) => BCrypt.Net.BCrypt.Verify(text, hashText);
}
