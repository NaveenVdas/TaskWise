using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using TaskWise.Application.QueryServices.IRoleQueryServices;
using TaskWise.Application.QueryServices.Role;

namespace TaskWise.Infrastructure.QueryServices;

public sealed class RoleQueryService : IRoleQueryService
{
    private readonly TaskWiseDbContext _db;

    public RoleQueryService(TaskWiseDbContext db)
    {
        _db = db;
    }

    public async Task<ReadOnlyCollection<RoleInfo>> GetAll(CancellationToken ct)
    {
        IQueryable<RoleInfo> query = from r in _db.Roles
                                     select new RoleInfo
                                     {
                                         Id = r.Id,
                                         Name = r.Name
                                     };

        return (await query.ToListAsync(ct)).AsReadOnly();
    }
}
