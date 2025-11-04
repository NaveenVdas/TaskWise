using RoleId = TaskWise.Domain.DomainModels.Enums.Role;

namespace TaskWise.Application.BusinessServices.Auth;

public sealed record LoginResponseCommand(int UserId, string Email, RoleId Role, string Token);
