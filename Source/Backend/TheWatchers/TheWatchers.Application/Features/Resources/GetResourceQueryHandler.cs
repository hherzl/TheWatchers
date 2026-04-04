using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.Resources;

public sealed class GetResourceQueryHandler(IResourcesService service) : IRequestHandler<GetResourceQuery, SingleResponse<ResourceDetailsModel>>
{
    public async Task<SingleResponse<ResourceDetailsModel>> HandleAsync(GetResourceQuery request, CancellationToken ct = default)
    {
        return new(await service.GetResourceAsync(request, ct));
    }
}
