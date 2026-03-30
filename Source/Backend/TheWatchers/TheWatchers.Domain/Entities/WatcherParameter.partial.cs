namespace TheWatchers.Domain.Entities;

public partial class WatcherParameter
{
    public WatcherParameter(string parameter, string value, bool isDefault)
    {
        Active = true;

        Parameter = parameter;
        Value = value;
        IsDefault = isDefault;
    }
}
