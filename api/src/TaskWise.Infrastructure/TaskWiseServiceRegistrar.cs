using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskWise.Application.BusinessServices.Role;
using TaskWise.Application.QueryServices.Role;
using TaskWise.Infrastructure.QueryServices;

namespace TaskWise.Infrastructure;

public static class TaskWiseServiceRegistrar
{
    public static IServiceCollection RegisterTaskWiseServices(this IServiceCollection services, IConfiguration configuration) =>
        services.RegisterTaskWiseInfrastructureServices(configuration)
            .RegisterTaskWiseApplicationServices();

    public static IServiceCollection RegisterTaskWiseInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<TaskWiseDbContext>(options =>
                  {
                      options.UseSqlServer(configuration.GetConnectionString("TaskWise"));
                  });

    public static IServiceCollection RegisterTaskWiseApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRoleQueryService, RoleQueryService>();
        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}
