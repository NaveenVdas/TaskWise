using TaskWise.Api.Common.Extensions;
using TaskWise.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureApplicationLogging();
builder.Services
    .AddApiServices()
    .RegisterTaskWiseServices(builder.Configuration);
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();
app.ConfigurePipeline();
app.Run();
