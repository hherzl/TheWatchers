using TheWatchers.Domain.Common;

namespace TheWatchers.Domain.Entities;

public partial class ResourceWatchParameter : Entity
{
    public ResourceWatchParameter()
    {
    }

    public ResourceWatchParameter(int? id)
    {
        Id = id;
    }

    public int? Id { get; set; }
    public int? ResourceWatchId { get; set; }
    public string Parameter { get; set; }
    public string Value { get; set; }
    public string Description { get; set; }

    public virtual ResourceWatch ResourceWatch { get; set; }
}
