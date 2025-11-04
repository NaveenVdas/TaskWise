namespace TaskWise.Application.Common.Security;

public interface IHashGenerator
{
    string GenerateHash(string text);
    bool VerifyHash(string text, string hashText);
}
