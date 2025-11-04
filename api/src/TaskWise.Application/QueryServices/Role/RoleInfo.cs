using RoleId = TaskWise.Domain.DomainModels.Enums.Role;

namespace TaskWise.Application.QueryServices.Role;

public sealed class RoleInfo
{
    public RoleId Id { get; init; }
    public required string Name { get; init; }
}
