using System.Collections.ObjectModel;
using TheWatchers.Domain.Common;

namespace TheWatchers.Domain.Entities;

public partial class Environment : Entity
{
    public Environment()
    {
    }

    public Environment(short? id)
    {
        Id = id;
    }

    public short? Id { get; set; }
    public string Name { get; set; }

    public virtual Collection<ResourceWatch> ResourceWatches { get; set; }
}
