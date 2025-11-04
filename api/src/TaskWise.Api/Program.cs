using TaskWise.Api.Common.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureApplicationLogging();
builder.Services.AddApiServices();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();
app.ConfigurePipeline();
app.Run();
