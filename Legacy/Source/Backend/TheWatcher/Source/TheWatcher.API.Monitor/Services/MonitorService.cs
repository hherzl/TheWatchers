using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TheWatcher.API.Monitor.Hubs;
using TheWatcher.API.Monitor.Hubs.Models;
using TheWatcher.API.Monitor.Services.Models;
using TheWatcher.Domain.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.API.Monitor.Services
{
    public class MonitorService : IHostedService, IDisposable
    {
        private readonly ILogger<MonitorService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IServiceScope _serviceScope;
        private readonly List<Timer> _timers;

        public MonitorService(ILogger<MonitorService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _serviceScope = _serviceScopeFactory.CreateScope();
            _timers = new();
        }

        private IHubContext<MonitorHub> _hubContext;

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Starting watchers...");

            _hubContext = _serviceScope.ServiceProvider.GetService<IHubContext<MonitorHub>>();

            var dbContext = _serviceScope.ServiceProvider.GetService<TheWatcherDbContext>();
            var list = await dbContext.GetResourceWatchItems().ToListAsync(stoppingToken);

            var model = list
                .Select(item => new ResourceWatchItemModel
                {
                    Id = item.Id,
                    ResourceId = item.ResourceId,
                    Resource = item.Resource,
                    ResourceCategory = item.ResourceCategory,
                    AssemblyQualifiedName = item.AssemblyQualifiedName,
                    Environment = item.Environment,
                    EnvironmentId = item.EnvironmentId,
                    Interval = item.Interval
                })
                .ToList()
                ;

            foreach (var resourceWatchItem in model)
            {
                var parameters = await dbContext
                    .ResourceWatchParameter
                    .Where(item => item.ResourceWatchId == resourceWatchItem.Id)
                    .ToListAsync()
                    ;

                foreach (var param in parameters)
                {
                    resourceWatchItem.Param.Values.Add(param.Parameter, param.Value);
                }

                _timers.Add(new Timer(Monitoring, resourceWatchItem, TimeSpan.Zero, TimeSpan.FromMilliseconds((double)resourceWatchItem.Interval)));
            }

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Stopping watchers...");

            foreach (var item in _timers)
            {
                item.Change(Timeout.Infinite, 0);
            }

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            foreach (var item in _timers)
            {
                item.Dispose();
            }
        }

        public async void Monitoring(object state)
        {
            if (state is ResourceWatchItemModel cast)
            {
                _logger.LogInformation($"Watcher for '{cast.Resource}' resource is executing in '{cast.Environment}' environment, interval: '{cast.Interval}'...");

                var watcherType = Type.GetType(cast.AssemblyQualifiedName, true);

                var watcherInstance = (IWatcher)Activator.CreateInstance(watcherType);

                var result = await watcherInstance.WatchAsync(cast.Param);

                if (result.IsSuccess)
                    _logger.LogInformation($"The watch for '{cast.Resource}' was 'Successfully' in '{cast.Environment}'");
                else
                    _logger.LogError($"The watch for '{cast.Resource}' was 'Failed' in '{cast.Environment}'");

                await _hubContext.Clients.All.SendAsync(HubMethods.ReceiveResourceWatch, new ResourceWatchArg
                {
                    Resource = cast.Resource,
                    ResourceId = cast.ResourceId,
                    Environment = cast.Environment,
                    EnvironmentId = cast.EnvironmentId,
                    IsSuccess = result.IsSuccess,
                    LastWatch = result.LastWatch
                });

                var dbContext = _serviceScope.ServiceProvider.GetService<TheWatcherDbContext>();

                var resourceWatch = await dbContext.GetResourceWatchAsync(cast.Id);

                resourceWatch.Successful = result.IsSuccess;
                resourceWatch.LastWatch = result.LastWatch;
                resourceWatch.WatchCount += 1;
                resourceWatch.LastUpdateDateTime = DateTime.Now;
                resourceWatch.LastUpdateUser = typeof(MonitorService).Name;

                var affectedRows = await dbContext.SaveChangesAsync();

                if (affectedRows > 0)
                    _logger.LogInformation($"Resource watch was updated for '{cast.Resource}' resource in '{cast.Environment}' environment");
            }
        }
    }
}
