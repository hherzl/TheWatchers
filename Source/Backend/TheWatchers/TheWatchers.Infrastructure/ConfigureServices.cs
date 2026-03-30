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
        services.AddScoped<TheWatchersDbContext>();

        services.AddScoped<IWatchersService, WatchersService>();

        return services;
    }
}
