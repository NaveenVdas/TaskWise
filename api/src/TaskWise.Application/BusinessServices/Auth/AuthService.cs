using TaskWise.Application.Common.Email;
using TaskWise.Application.Common.OperationHandler;
using TaskWise.Application.Common.Security;
using TaskWise.Application.Common.Security.Token;
using TaskWise.Application.Repository;
using TaskWise.Application.UnitOfWork;
using TaskWise.Domain.DomainModels;

namespace TaskWise.Application.BusinessServices.Auth;

public sealed class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IHashGenerator _hashGenerator;
    private readonly ITokenService _tokenService;
    private readonly IUserInviteRepository _userInviteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public AuthService(IUserRepository userRepository, IHashGenerator hashGenerator, ITokenService tokenService,
        IUserInviteRepository userInviteRepository, IUnitOfWork unitOfWork, IEmailService emailService)
    {
        _userRepository = userRepository;
        _hashGenerator = hashGenerator;
        _tokenService = tokenService;
        _userInviteRepository = userInviteRepository;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
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

    public async Task<OperationResult<bool>> InviteUser(InviteRequestCommand command, CancellationToken ct)
    {
        User? user = await _userRepository.GetByEmail(command.Email, ct);
        if (user is not null)
        {
            return OperationResult<bool>.ValidationError("User already exists.");
        }

        UserInvite? existingUserInvite = await _userInviteRepository.GetInviteByEmail(command.Email, ct);
        if (existingUserInvite is not null)
        {
            if (existingUserInvite.IsValid)
            {
                existingUserInvite.IsValid = false;
                _userInviteRepository.UpdateInvite(existingUserInvite);
            }
            if (existingUserInvite.IsAccepted)
            {
                return OperationResult<bool>.ValidationError("User already exists.");
            }
        }
        string token = _tokenService.GenerateInviteToken(command.Email, command.Role, 24);
        UserInvite newInvite = new()
        {
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Role = command.Role,
            InvitedBy = command.InvitedBy,
            Token = token,
            InvitedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddHours(24), // Match token expiration (24 hours)
            IsValid = true,
            IsAccepted = false
        };

        await _userInviteRepository.CreateInvite(newInvite, ct);
        await _unitOfWork.SaveChanges(ct);

        // Send invitation email
        string recipientName = string.IsNullOrWhiteSpace(command.FirstName)
            ? command.LastName
            : $"{command.FirstName} {command.LastName}";

        bool emailSent = await _emailService.SendInviteEmailAsync(
            command.Email,
            recipientName,
            token,
            string.Empty, // inviteUrl will be constructed in the service
            ct);

        if (!emailSent)
        {
            // Consider logging this as a warning or adding a retry mechanism
        }

        return OperationResult<bool>.Success(!string.IsNullOrEmpty(token));
    }
}
