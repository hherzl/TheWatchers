using Microsoft.EntityFrameworkCore;
using TheWatchers.Application.Features.Resources;
using TheWatchers.Application.Features.ResourcesCategories;
using TheWatchers.Application.Features.ResourcesWatches;
using TheWatchers.Application.Services;
using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence;
using TheWatchers.Infrastructure.Persistence.QuerySpecs;
using TheWatchers.SharedKernel.Models;

namespace TheWatchers.Infrastructure.Services;

public sealed class ResourcesService(TheWatchersDbContext dbContext) : IResourcesService
{
    public async Task<IList<ResourceCategoryItemModel>> GetResourcesCategoriesAsync(GetResourcesCategoriesQuery request, CancellationToken ct = default)
    {
        return await dbContext.GetResourcesCategories().ToListAsync(ct);
    }

    public async Task<ResourceCategoryDetailsModel> GetResourceCategoryAsync(GetResourceCategoryQuery request, CancellationToken ct = default)
    {
        var entity = await dbContext.GetResourceCategoryAsync(request.Id, false, true, ct);
        if (entity == null)
            return null;

        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            WatcherId = entity.WatcherId
        };
    }

    public async Task<IList<ResourceItemModel>> GetResourcesAsync(GetResourcesQuery request, CancellationToken ct = default)
    {
        return await dbContext.GetResources().ToListAsync(ct);
    }

    public async Task<ResourceDetailsModel> GetResourceAsync(GetResourceQuery request, CancellationToken ct = default)
    {
        var entity = await dbContext.GetResourceAsync(request.Id, false, true, ct);
        if (entity == null)
            return null;

        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            ResourceCategoryId = entity.ResourceCategoryId,
            ResourceCategory = entity.ResourceCategory.Name
        };
    }

    public async Task<IList<ResourceWatchItemModel>> GetResourcesWatchesAsync(GetResourcesWatchesQuery request, CancellationToken ct = default)
    {
        return await dbContext.GetResourceWatches().ToListAsync(ct);
    }

    public async Task<IList<ResourceWatchParameter>> GetResourceWatchParametersAsync(int? resourceWatchId, CancellationToken ct = default)
    {
        return await dbContext.ResourceWatchParameters.AddQuerySpec(new GetResourceWatchParameterByQuerySpec(resourceWatchId)).ToListAsync(ct);
    }
}
