using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using TheWatcher.API.Common;
using TheWatcher.Domain.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .Services
    .AddDbContext<TheWatcherDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TheWatcher")))
    ;

var corsSettings = new CorsSettings();

builder.Configuration.Bind("CorsSettings", corsSettings);

foreach (var item in corsSettings.Policies)
{
    builder.Services.AddCors(options => options.AddPolicy(item.Name, builder =>
    {
        builder
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins(item.Policy.Origins.ToList().ToArray())
            ;
    }));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

foreach (var item in corsSettings.Policies)
{
    app.UseCors(item.Name);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("TheWatcher.API.Panel.log")
    .CreateLogger()
    ;

try
{
    Log.Information("Starting web host");
    app.Run();
    return 1;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 0;
}
finally
{
    Log.CloseAndFlush();
}
