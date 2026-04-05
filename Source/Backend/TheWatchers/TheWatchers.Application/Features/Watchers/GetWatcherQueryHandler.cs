using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.Watchers;

public sealed class GetWatcherQueryHandler(IWatchersService service)
    : IRequestHandler<GetWatcherQuery, SingleResponse<WatcherDetailsModel>>
{
    public async Task<SingleResponse<WatcherDetailsModel>> HandleAsync(GetWatcherQuery request, CancellationToken ct = default)
    {
        var model = await service.GetWatcherAsync(request, ct);
        if (model == null)
            return null;

        return new(model);
    }
}
