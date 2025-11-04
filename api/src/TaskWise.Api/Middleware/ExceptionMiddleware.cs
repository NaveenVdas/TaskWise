using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TaskWise.Api.Middleware;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment environment, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _environment = environment;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error occurred. {Method} {Path} CorrelationId:{CorrelationId}",
                context.Request.Method, context.Request.Path, context.TraceIdentifier);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var problem = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Unexpected error occurred",
            };

            problem.Extensions["CorrelationId"] = context.TraceIdentifier;
            if (_environment.IsDevelopment())
            {
                problem.Extensions["message"] = ex.Message;
                problem.Extensions["stackTrace"] = ex.StackTrace;
            }

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
