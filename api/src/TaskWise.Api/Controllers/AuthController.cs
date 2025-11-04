using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskWise.Api.Common.Adapters;
using TaskWise.Api.Features.Auth.Login;
using TaskWise.Application.BusinessServices.Auth;
using TaskWise.Application.Common.OperationHandler;

namespace TaskWise.Api.Controllers;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IResultAdapter _resultAdapter;

    public AuthController(IAuthService authService, IResultAdapter resultAdapter)
    {
        _authService = authService;
        _resultAdapter = resultAdapter;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequestModel model, CancellationToken ct)
    {
        OperationResult<LoginResponseCommand> result = await _authService.Login(model.ToCommand(), ct);

        return result.IsSuccess && result.Payload is not null
             ? Ok(new LoginResponseModel(result.Payload))
             : _resultAdapter.ToActionResult(result);
    }
}
