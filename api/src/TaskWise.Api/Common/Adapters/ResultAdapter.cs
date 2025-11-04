using Microsoft.AspNetCore.Mvc;
using TaskWise.Application.Common.OperationHandler;

namespace TaskWise.Api.Common.Adapters;

public sealed class ResultAdapter : IResultAdapter
{
    public IActionResult ToActionResult<T>(OperationResult<T> result)
    {
        return result.Status switch
        {
            OperationStatus.Success => new OkObjectResult(result),
            OperationStatus.NotFound => new NotFoundObjectResult(result),
            OperationStatus.UserNotActive => new UnauthorizedObjectResult(result),
            OperationStatus.Unauthorized => new UnauthorizedObjectResult(result),
            _ => throw new ArgumentOutOfRangeException(nameof(result.Status))
        };
    }
}
