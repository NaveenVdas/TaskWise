using TaskWise.Application.QueryServices.Role;
using RoleId = TaskWise.Domain.DomainModels.Enums.Role;

namespace TaskWise.Api.Features.Role;

public sealed class RoleResponseModel
{
    public RoleResponseModel(RoleInfo role)
    {
        Id = role.Id;
        Name = role.Name;
    }

    public RoleId Id { get; }
    public string Name { get; }
}
