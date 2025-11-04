using RoleId = TaskWise.Domain.DomainModels.Enums.Role;

namespace TaskWise.Domain.DomainModels;

public sealed class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public RoleId Role { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
