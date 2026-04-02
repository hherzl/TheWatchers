using TheWatchers.WebApi.Services;

namespace TheWatchers.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<TheWatchersDbInitializer>();
        services.AddHostedService<MonitorBackgroundService>();

        return services;
    }
}
