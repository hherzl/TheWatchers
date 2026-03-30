using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.Watchers.PingClient;

namespace TheWatchers.WebApi.Services;

public sealed class TheWatchersDbInitializer(TheWatchersDbContext dbContext)
{
    public async Task SeedAsync(CancellationToken ct = default)
    {
        if (!dbContext.Watchers.Any())
        {
            dbContext.Watchers.Add(new("Ping watcher", "Watcher for Ping requests", new PingWatcher(), new WatcherParameter("IPAddress", "", false)));

            await dbContext.SaveChangesAsync(ct);
        }
    }
}
