using TaskWise.Domain.DomainModels;

namespace TaskWise.Application.Repository;

public interface IUserInviteRepository
{
    Task CreateInvite(UserInvite invite, CancellationToken ct);
    Task<UserInvite?> GetInviteByEmail(string email, CancellationToken ct);
    void UpdateInvite(UserInvite invite);
}
