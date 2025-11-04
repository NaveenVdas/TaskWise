using Serilog;
using Serilog.Context;

namespace TaskWise.Api.Common.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
            {
                await next(context);
            }
        });

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseSerilogRequestLogging();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
