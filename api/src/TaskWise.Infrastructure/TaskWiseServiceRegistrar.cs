using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskWise.Infrastructure;

public static class TaskWiseServiceRegistrar
{
    public static IServiceCollection RegisterTaskWiseServices(this IServiceCollection services, IConfiguration configuration) =>
        services.RegisterTaskWiseInfrastructureServices(configuration);

    public static IServiceCollection RegisterTaskWiseInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<TaskWiseDbContext>(options =>
                  {
                      options.UseSqlServer(configuration.GetConnectionString("TaskWise"));
                  });
}
