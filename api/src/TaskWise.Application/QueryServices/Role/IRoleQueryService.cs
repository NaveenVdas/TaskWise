using System.Collections.ObjectModel;
using TaskWise.Application.QueryServices.IRoleQueryServices;

namespace TaskWise.Application.QueryServices.Role;

public interface IRoleQueryService
{
    Task<ReadOnlyCollection<RoleInfo>> GetAll(CancellationToken ct);
}
