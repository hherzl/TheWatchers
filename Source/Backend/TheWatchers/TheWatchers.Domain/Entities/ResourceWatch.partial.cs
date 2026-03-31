namespace TheWatchers.Domain.Entities;

public partial class ResourceWatch
{
    public ResourceWatch(short? resourceId, short? environmentId, int? interval, string description, params ResourceWatchParameter[] parameters)
    {
        Active = true;

        ResourceId = resourceId;
        EnvironmentId = environmentId;
        Successful = false;
        WatchCount = 0;
        Interval = interval;
        Description = description;

        ResourceWatchParameters = [];
        foreach (var parameter in parameters)
        {
            ResourceWatchParameters.Add(parameter);
        }
    }
}
