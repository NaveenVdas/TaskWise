using TaskWise.Domain.DomainModels.Enums;

namespace TaskWise.Application.Common.Security.Token;

public interface ITokenService
{
    string GenerateToken(int userId, string email, Role role);
}
