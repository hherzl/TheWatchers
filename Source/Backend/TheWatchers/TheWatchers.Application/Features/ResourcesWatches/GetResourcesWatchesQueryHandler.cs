using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.ResourcesWatches;

public sealed class GetResourcesWatchesQueryHandler(IResourcesService service) : IRequestHandler<GetResourcesWatchesQuery, ListResponse<ResourceWatchItemModel>>
{
    public async Task<ListResponse<ResourceWatchItemModel>> HandleAsync(GetResourcesWatchesQuery request, CancellationToken ct = default)
    {
        return new(await service.GetResourcesWatchesAsync(request, ct));
    }
}
