using Serilog;
using Serilog.Context;
using TaskWise.Api.Middleware;

namespace TaskWise.Api.Common.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseGlobalExceptionHandler();
        app.UseHttpsRedirection();

        app.Use(async (context, next) =>
        {
            using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
            {
                await next(context);
            }
        });
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
