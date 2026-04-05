using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.Resources;

public sealed class GetResourceQueryHandler(IResourcesService service)
    : IRequestHandler<GetResourceQuery, SingleResponse<ResourceDetailsModel>>
{
    public async Task<SingleResponse<ResourceDetailsModel>> HandleAsync(GetResourceQuery request, CancellationToken ct = default)
    {
        var model = await service.GetResourceAsync(request, ct);
        if (model == null)
            return null;

        return new(model);
    }
}
