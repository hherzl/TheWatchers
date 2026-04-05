using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.ResourcesCategories;

public sealed class GetResourceCategoryQueryHandler(IResourcesService service)
    : IRequestHandler<GetResourceCategoryQuery, SingleResponse<ResourceCategoryDetailsModel>>
{
    public async Task<SingleResponse<ResourceCategoryDetailsModel>> HandleAsync(GetResourceCategoryQuery request, CancellationToken ct = default)
    {
        var model = await service.GetResourceCategoryAsync(request, ct);
        if (model == null)
            return null;

        return new(model);
    }
}
