using Microsoft.EntityFrameworkCore;
using TaskWise.Application.Repository;
using TaskWise.Domain.DomainModels;

namespace TaskWise.Infrastructure.Repository;

public sealed class UserRepository : IUserRepository
{
    private readonly TaskWiseDbContext _db;

    public UserRepository(TaskWiseDbContext db)
    {
        _db = db;
    }

    public async Task<User> CreateUser(User user, CancellationToken ct) => (await _db.Users.AddAsync(user, ct)).Entity;

    public async Task<User?> GetByEmail(string email, CancellationToken ct) =>
        await _db.Users.FirstOrDefaultAsync(u => u.Email == email, ct);
}
