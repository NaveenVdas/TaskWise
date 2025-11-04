using TaskWise.Domain.DomainModels;

namespace TaskWise.Application.Repository;

public interface IUserRepository
{
    Task<User> CreateUser(User user, CancellationToken ct);
    Task<User?> GetByEmail(string email, CancellationToken ct);
}
