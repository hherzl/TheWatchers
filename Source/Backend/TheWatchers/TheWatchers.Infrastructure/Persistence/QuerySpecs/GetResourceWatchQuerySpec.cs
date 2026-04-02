using TheWatchers.Domain.Common;
using TheWatchers.Domain.Entities;

namespace TheWatchers.Infrastructure.Persistence.QuerySpecs;

public class GetResourceWatchQuerySpec : BaseQuerySpec<ResourceWatch>
{
    public GetResourceWatchQuerySpec(int? id)
    {
        Criteria = entity => entity.Id == id;
    }
}
