using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using TaskWise.Api.Features.Role;
using TaskWise.Application.BusinessServices.Role;
using TaskWise.Application.QueryServices.IRoleQueryServices;

namespace TaskWise.Api.Controllers;

[Route("roles")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        ReadOnlyCollection<RoleInfo> roles = await _roleService.GetAll(ct);

        return Ok(roles.Select(r => new RoleResponseModel(r)));
    }
}
