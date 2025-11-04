namespace TaskWise.Api.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this WebApplication app)
        => app.UseMiddleware<ExceptionMiddleware>();
}
