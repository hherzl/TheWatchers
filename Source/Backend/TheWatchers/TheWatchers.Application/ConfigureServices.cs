using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheWatchers.Application.Features.Resources;
using TheWatchers.Application.Features.ResourcesWatches;
using TheWatchers.Application.Features.Watchers;

namespace TheWatchers.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<GetWatchersQueryHandler>();
        services.AddScoped<GetWatcherQueryHandler>();
        services.AddScoped<GetResourcesQueryHandler>();
        services.AddScoped<GetResourceQueryHandler>();
        services.AddScoped<GetResourcesWatchesQueryHandler>();

        return services;
    }
}
