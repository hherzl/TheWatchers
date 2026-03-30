using TheWatchers.Application.Features.Watchers;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Application.Services;

public interface IWatchersService
{
    Task<IList<WatcherItemModel>> GetWatchersAsync(GetWatchersQuery request, CancellationToken ct = default);
    Task<WatcherDetailsModel> GetWatcherAsync(GetWatcherQuery request, CancellationToken ct = default);
}
