using TheWatchers.Application;
using TheWatchers.Infrastructure;
using TheWatchers.WebApi;
using TheWatchers.WebApi.Endpoints;
using TheWatchers.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

app.MapWatchers();
app.MapResourceWatches();

app.Run();
