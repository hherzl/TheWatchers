using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.ResourcesCategories;

public sealed class GetResourcesCategoriesQueryHandler(IResourcesService service)
    : IRequestHandler<GetResourcesCategoriesQuery, ListResponse<ResourceCategoryItemModel>>
{
    public async Task<ListResponse<ResourceCategoryItemModel>> HandleAsync(GetResourcesCategoriesQuery request, CancellationToken ct = default)
    {
        return new(await service.GetResourcesCategoriesAsync(request, ct));
    }
}
