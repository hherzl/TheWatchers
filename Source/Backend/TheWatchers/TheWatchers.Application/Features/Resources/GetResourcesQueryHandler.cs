using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.Resources;

public sealed class GetResourcesQueryHandler(IResourcesService service) : IRequestHandler<GetResourcesQuery, ListResponse<ResourceItemModel>>
{
    public async Task<ListResponse<ResourceItemModel>> HandleAsync(GetResourcesQuery request, CancellationToken ct = default)
    {
        return new(await service.GetResourcesAsync(request, ct));
    }
}
