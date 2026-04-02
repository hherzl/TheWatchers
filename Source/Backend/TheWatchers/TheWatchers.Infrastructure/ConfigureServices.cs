using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheWatchers.Application.Services;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.Infrastructure.Services;

namespace TheWatchers.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrasructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TheWatchersDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TheWatchers")));

        services.AddScoped<IWatchersService, WatchersService>();
        services.AddScoped<IResourcesService, ResourcesService>();

        return services;
    }
}
