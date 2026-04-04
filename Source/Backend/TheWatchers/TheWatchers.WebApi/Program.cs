using Serilog;
using TheWatchers.Application;
using TheWatchers.Infrastructure;
using TheWatchers.WebApi;
using TheWatchers.WebApi.Endpoints;
using TheWatchers.WebApi.Hubs;
using TheWatchers.WebApi.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(@"C:\Logs\TheWatchers", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
            .CreateLogger();

    // Add services to the container.
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.Services.AddSerilog();

    builder.Services.AddApplicationServices(builder.Configuration);
    builder.Services.AddInfrasructureServices(builder.Configuration);
    builder.Services.AddServices(builder.Configuration);

    var app = builder.Build();

    if (args.Contains("--seed"))
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var dbInitializer = serviceScope.ServiceProvider.GetRequiredService<TheWatchersDbInitializer>();
        await dbInitializer.SeedAsync();
        return;
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    var policies = builder.Configuration.GetSection("Policies").Get<CorsPolicy[]>();
    foreach (var policy in policies)
    {
        app.UseCors(policy.Name);
    }

    app.MapHub<MonitorHub>("/monitorhub");

    app.MapWatchers();
    app.MapResources();
    app.MapResourceWatches();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
