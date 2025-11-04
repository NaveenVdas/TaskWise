using TaskWise.Application.Common.OperationHandler;
using TaskWise.Application.Common.Security;
using TaskWise.Application.Common.Security.Token;
using TaskWise.Application.Repository;
using TaskWise.Domain.DomainModels;

namespace TaskWise.Application.BusinessServices.Auth;

public sealed class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IHashGenerator _hashGenerator;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository userRepository, IHashGenerator hashGenerator, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _hashGenerator = hashGenerator;
        _tokenService = tokenService;
    }

    public async Task<OperationResult<LoginResponseCommand>> Login(LoginCommand command, CancellationToken ct)
    {
        User? user = await _userRepository.GetByEmail(command.Email.ToLowerInvariant(), ct);
        if (user is null)
        {
            return OperationResult<LoginResponseCommand>.NotFound("User not found.");
        }

        if (!user.IsActive)
        {
            return OperationResult<LoginResponseCommand>.UserNotActive("InActive user.");
        }

        if (!_hashGenerator.VerifyHash(command.Password, user.PasswordHash))
        {
            return OperationResult<LoginResponseCommand>.Unauthorized("Invalid credentials.");
        }

        string token = _tokenService.GenerateToken(user.Id, user.Email, user.Role);
        return OperationResult<LoginResponseCommand>.Success(new LoginResponseCommand(user.Id, user.Email, user.Role, token));
    }
}
