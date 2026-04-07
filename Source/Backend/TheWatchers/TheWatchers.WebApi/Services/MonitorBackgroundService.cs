using System.Collections.ObjectModel;
using Microsoft.AspNetCore.SignalR;
using TheWatchers.Application.Services;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.SharedKernel.Core;
using TheWatchers.SharedKernel.Models;
using TheWatchers.WebApi.Hubs;

namespace TheWatchers.WebApi.Services;

public sealed class MonitorBackgroundService(ILogger<MonitorBackgroundService> logger, IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    private readonly Collection<Timer> _timers = [];

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        using var serviceScope = serviceScopeFactory.CreateScope();

        var resourcesService = serviceScope.ServiceProvider.GetRequiredService<IResourcesService>();
        var resourcesWatches = await resourcesService.GetResourcesWatchesAsync(new(), ct);
        foreach (var resourceWatch in resourcesWatches)
        {
            var parameters = await resourcesService.GetResourceWatchParametersAsync(resourceWatch.Id, ct);
            foreach (var parameter in parameters)
            {
                resourceWatch.Parameters.Add(parameter.Parameter, parameter.Value);
            }

            _timers.Add(new Timer(Monitoring, resourceWatch, TimeSpan.Zero, TimeSpan.FromMilliseconds((double)resourceWatch.Interval)));
        }
    }

    public async void Monitoring(object state)
    {
        if (state is not ResourceWatchItemModel cast)
            return;

        using var serviceScope = serviceScopeFactory.CreateScope();

        var watcherType = Type.GetType(cast.AssemblyQualifiedName, true);
        var watcherInstance = (IWatcher)Activator.CreateInstance(watcherType);
        var result = await watcherInstance.WatchAsync(cast.Parameters);
        if (result.IsSuccess)
            logger.LogInformation($"The watch for '{cast.Resource}' was 'successfully' in '{cast.Environment}' environment");
        else
            logger.LogError($"The watch for '{cast.Resource}' was 'failed' in '{cast.Environment}' environment");

        using var dbContext = serviceScope.ServiceProvider.GetService<TheWatchersDbContext>();

        var resourceWatch = await dbContext.GetResourceWatchAsync(cast.Id, tracking: true);

        resourceWatch.Successful = result.IsSuccess;
        resourceWatch.LastWatch = result.LastWatch;
        resourceWatch.WatchCount += 1;
        resourceWatch.LastUpdateAt = DateTime.Now;
        resourceWatch.LastUpdateBy = typeof(MonitorBackgroundService).Name;

        var affectedRows = await dbContext.SaveChangesAsync();
        if (affectedRows > 0)
        {
            logger.LogInformation($"Resource watch was updated for '{cast.Resource}' resource in '{cast.Environment}' environment");

            var hubContext = serviceScope.ServiceProvider.GetService<IHubContext<MonitorHub>>();
            logger.LogInformation($"Broadcasting the result watch for '{cast.Resource}' in '{cast.Environment}' environment...");

            await hubContext.Clients.All.SendAsync(
                HubMethods.ReceiveResourceWatch, new ResourceWatchArgs
                {
                    Id = cast.Id,
                    Resource = cast.Resource,
                    ResourceCategory = cast.ResourceCategory,
                    Environment = cast.Environment,
                    Successful = cast.Successful,
                    WatchCount = resourceWatch.WatchCount,
                    LastWatch = resourceWatch.LastWatch,
                    Cols = 1,
                    Rows = 1
                }
            );
        }
    }
}
