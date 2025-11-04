using TaskWise.Application.UnitOfWork;

namespace TaskWise.Infrastructure;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly TaskWiseDbContext _db;

    public UnitOfWork(TaskWiseDbContext db)
    {
        _db = db;
    }

    public async Task SaveChanges(CancellationToken ct) => await _db.SaveChangesAsync(ct);
}
