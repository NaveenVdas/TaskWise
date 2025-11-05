using RoleId = TaskWise.Domain.DomainModels.Enums.Role;

namespace TaskWise.Domain.DomainModels;

public sealed class UserInvite
{
    public int Id { get; set; }
    public required string? FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required RoleId Role { get; set; }
    public required string Token { get; set; }
    public int InvitedBy { get; set; }
    public DateTime InvitedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsValid { get; set; }
    public bool IsAccepted { get; set; }
}
