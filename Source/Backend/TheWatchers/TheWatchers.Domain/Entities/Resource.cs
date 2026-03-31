using System.Collections.ObjectModel;
using TheWatchers.Domain.Common;

namespace TheWatchers.Domain.Entities;

public partial class Resource : Entity
{
    public Resource()
    {
    }

    public Resource(short? id)
    {
        Id = id;
    }

    public short? Id { get; set; }
    public string Name { get; set; }
    public short? ResourceCategoryId { get; set; }

    public virtual ResourceCategory ResourceCategory { get; set; }
    public virtual Collection<ResourceWatch> ResourceWatches { get; set; }
}
