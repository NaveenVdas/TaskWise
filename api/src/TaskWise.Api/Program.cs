using TaskWise.Api.Common.Extensions;
using TaskWise.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureApplicationLogging();
builder.Services
    .AddApiServices()
    .AddSwaggerConfiguration()
    .RegisterTaskWiseServices(builder.Configuration)
    .AddValidationServices()
    .AddJwtAuthentication(builder.Configuration)
    .AddAuthorizationPolicies()
    .AddApiDependencies();
WebApplication app = builder.Build();
app.ConfigurePipeline();
app.Run();
