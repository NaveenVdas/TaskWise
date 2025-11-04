using Serilog;

namespace TaskWise.Api.Common.Extensions;

public static class LoggingExtensions
{
    public static IHostBuilder ConfigureApplicationLogging(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, services, configuration) =>
        {
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext();
        });
        return hostBuilder;
    }
}
