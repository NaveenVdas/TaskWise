using TaskWise.Application.BusinessServices.Auth;

namespace TaskWise.Api.Features.Auth.Login;

public sealed class LoginRequestModel
{
    public required string Email { get; init; }
    public required string Password { get; init; }

    public LoginCommand ToCommand() => new LoginCommand(Email, Password);
}
