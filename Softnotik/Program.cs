using Serilog;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Softnotik.Middleware;
using Softnotik.Shared.Application;
using Softnotik.Shared.Infrastructure;
using Softnotik.Shared.Presentation.Endpoints;
using Softnotik.Modules.CustomerModule.Infrastructure;
using Softnotik.Extensions;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddApplication([Softnotik.Modules.CustomerModule.Application.AssemblyReference.Assembly]);

string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;

builder.Services.AddInfrastructure([], databaseConnectionString);
builder.Configuration.AddModuleConfiguration(["customermodule"]);

builder.Services.AddCors();
builder.Services.AddHealthChecks();
builder.Services.AddCustomerModule(builder.Configuration);
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseCors(x =>
{
    x.WithOrigins(builder.Configuration["AllowedCorsOrigin"]
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(o => o.RemovePostFix("/"))
        .ToArray())
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.MapEndpoints();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.Run();