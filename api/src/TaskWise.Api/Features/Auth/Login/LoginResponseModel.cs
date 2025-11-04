using TaskWise.Application.BusinessServices.Auth;

namespace TaskWise.Api.Features.Auth.Login;

public sealed class LoginResponseModel
{
    public LoginResponseModel(LoginResponseCommand command)
    {
        UserId = command.UserId;
        Email = command.Email;
        Role = command.Role.ToString();
        Token = command.Token;
    }

    public int UserId { get; }
    public string Email { get; }
    public string Role { get; }
    public string Token { get; }
}
