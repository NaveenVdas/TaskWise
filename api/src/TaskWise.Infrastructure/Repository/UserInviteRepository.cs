using Microsoft.EntityFrameworkCore;
using TaskWise.Application.Repository;
using TaskWise.Domain.DomainModels;

namespace TaskWise.Infrastructure.Repository;

public sealed class UserInviteRepository : IUserInviteRepository
{
    private readonly TaskWiseDbContext _db;

    public UserInviteRepository(TaskWiseDbContext db)
    {
        _db = db;
    }

    public async Task CreateInvite(UserInvite invite, CancellationToken ct) => await _db.UserInvites.AddAsync(invite, ct);

    public async Task<UserInvite?> GetInviteByEmail(string email, CancellationToken ct) =>
        await _db.UserInvites.FirstOrDefaultAsync(i => i.Email == email, ct);

    public void UpdateInvite(UserInvite invite) => _db.UserInvites.Update(invite);
}
