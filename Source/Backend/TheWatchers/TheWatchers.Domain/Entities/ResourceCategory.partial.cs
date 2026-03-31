namespace TheWatchers.Domain.Entities;

public partial class ResourceCategory
{
    public ResourceCategory(string name, short? watcherId)
    {
        Active = true;

        Name = name;
        WatcherId = watcherId;
    }
}
