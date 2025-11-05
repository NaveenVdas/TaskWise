using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskWise.Application.BusinessServices.Auth;
using TaskWise.Application.BusinessServices.Role;
using TaskWise.Application.Common.Email;
using TaskWise.Application.Common.Security;
using TaskWise.Application.Common.Security.Token;
using TaskWise.Application.QueryServices.Role;
using TaskWise.Application.Repository;
using TaskWise.Application.UnitOfWork;
using TaskWise.Infrastructure.QueryServices;
using TaskWise.Infrastructure.Repository;
using TaskWise.Infrastructure.Services.Email;

namespace TaskWise.Infrastructure;

public static class TaskWiseServiceRegistrar
{
    public static IServiceCollection RegisterTaskWiseServices(this IServiceCollection services, IConfiguration configuration) =>
        services.RegisterTaskWiseInfrastructureServices(configuration)
            .RegisterTaskWiseApplicationServices(configuration);

    public static IServiceCollection RegisterTaskWiseInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<TaskWiseDbContext>(options =>
                  {
                      options.UseSqlServer(configuration.GetConnectionString("TaskWise"));
                  });

    public static IServiceCollection RegisterTaskWiseApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRoleQueryService, RoleQueryService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAuthService, AuthService>();

        services.Configure<TokenSettings>(configuration.GetSection("TokenSettings"));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IHashGenerator, HashGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserInviteRepository, UserInviteRepository>();

        // Email service registration
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
