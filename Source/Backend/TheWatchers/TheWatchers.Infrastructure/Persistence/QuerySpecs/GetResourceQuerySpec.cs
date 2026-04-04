using TheWatchers.Domain.Common;
using TheWatchers.Domain.Entities;

namespace TheWatchers.Infrastructure.Persistence.QuerySpecs;

public class GetResourceQuerySpec : BaseQuerySpec<Resource>
{
    public GetResourceQuerySpec(int? id)
    {
        Criteria = entity => entity.Id == id;
    }
}
