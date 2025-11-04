using System.Collections.ObjectModel;
using TaskWise.Application.QueryServices.IRoleQueryServices;

namespace TaskWise.Application.BusinessServices.Role;

public interface IRoleService
{
    Task<ReadOnlyCollection<RoleInfo>> GetAll(CancellationToken ct);
}
