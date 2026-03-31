namespace TheWatchers.Domain.Entities;

public partial class ResourceWatchParameter
{
    public ResourceWatchParameter(short? resourceWatchId, string parameter, string value, string description)
    {
        Active = true;

        ResourceWatchId = resourceWatchId;
        Parameter = parameter;
        Value = value;
        Description = description;
    }
}
