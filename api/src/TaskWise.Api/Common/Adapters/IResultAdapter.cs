using Microsoft.AspNetCore.Mvc;
using TaskWise.Application.Common.OperationHandler;

namespace TaskWise.Api.Common.Adapters;

public interface IResultAdapter
{
    IActionResult ToActionResult<T>(OperationResult<T> result);
}
