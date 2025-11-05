using TaskWise.Application.BusinessServices.Auth;
using RoleId = TaskWise.Domain.DomainModels.Enums.Role;

namespace TaskWise.Api.Features.Auth.InviteUser;

public sealed class InviteRequestModel
{
    public required string? FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required RoleId Role { get; init; }
    public int InvitedBy { get; set; }

    public InviteRequestCommand ToCommand() =>
        new InviteRequestCommand(FirstName, LastName, Email.ToLowerInvariant(), Role, InvitedBy);
}
