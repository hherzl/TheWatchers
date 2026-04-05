using TheWatchers.Domain.Common;
using TheWatchers.Domain.Entities;

namespace TheWatchers.Infrastructure.Persistence.QuerySpecs;

public class GetResourceCategoryQuerySpec : BaseQuerySpec<ResourceCategory>
{
    public GetResourceCategoryQuerySpec(int? id)
    {
        Criteria = entity => entity.Id == id;
    }
}
