using RoleId = TaskWise.Domain.DomainModels.Enums.Role;

namespace TaskWise.Application.BusinessServices.Auth;

public sealed record InviteRequestCommand(string? FirstName, string LastName, string Email, RoleId Role, int InvitedBy)
{
}
