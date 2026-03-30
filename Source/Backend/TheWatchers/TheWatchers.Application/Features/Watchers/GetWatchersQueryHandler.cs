using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.Watchers;

public sealed class GetWatchersQueryHandler(IWatchersService service) : IRequestHandler<GetWatchersQuery, ListResponse<WatcherItemModel>>
{
    public async Task<ListResponse<WatcherItemModel>> HandleAsync(GetWatchersQuery request, CancellationToken ct = default)
    {
        return new(await service.GetWatchersAsync(request, ct));
    }
}
