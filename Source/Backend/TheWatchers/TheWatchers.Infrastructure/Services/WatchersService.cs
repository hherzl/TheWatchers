using TheWatchers.Application.Features.Watchers;
using TheWatchers.Application.Services;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Services;

public sealed class WatchersService(TheWatchersDbContext dbContext) : IWatchersService
{
    public async Task<IList<WatcherItemModel>> GetWatchersAsync(GetWatchersQuery request, CancellationToken ct = default)
    {
        return await Task.FromResult(new List<WatcherItemModel>());
    }

    public async Task<WatcherDetailsModel> GetWatcherAsync(GetWatcherQuery request, CancellationToken ct = default)
    {
        return await Task.FromResult(new WatcherDetailsModel());
    }
}
