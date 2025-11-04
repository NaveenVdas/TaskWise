using System.Collections.ObjectModel;

namespace TaskWise.Application.QueryServices.Role;

public interface IRoleQueryService
{
    Task<ReadOnlyCollection<RoleInfo>> GetAll(CancellationToken ct);
}
