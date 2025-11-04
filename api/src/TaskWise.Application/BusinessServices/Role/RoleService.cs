using System.Collections.ObjectModel;
using TaskWise.Application.QueryServices.Role;

namespace TaskWise.Application.BusinessServices.Role;

public sealed class RoleService : IRoleService
{
    private readonly IRoleQueryService _roleQueryServices;

    public RoleService(IRoleQueryService roleQueryServices)
    {
        _roleQueryServices = roleQueryServices;
    }

    public async Task<ReadOnlyCollection<RoleInfo>> GetAll(CancellationToken ct) => await _roleQueryServices.GetAll(ct);
}
