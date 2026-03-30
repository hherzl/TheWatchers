using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheWatchers.Application.Features.Watchers;

namespace TheWatchers.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<GetWatchersQueryHandler>();
        services.AddScoped<GetWatcherQueryHandler>();

        return services;
    }
}
