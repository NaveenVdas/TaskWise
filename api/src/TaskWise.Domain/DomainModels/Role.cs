using RoleId = TaskWise.Domain.DomainModels.Enums.Role;

namespace TaskWise.Domain.DomainModels;

public sealed class Role
{
    public RoleId Id { get; set; }
    public required string Name { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
}
