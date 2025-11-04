using TaskWise.Application.Common.OperationHandler;

namespace TaskWise.Application.BusinessServices.Auth;

public interface IAuthService
{
    Task<OperationResult<LoginResponseCommand>> Login(LoginCommand command, CancellationToken ct);
}
