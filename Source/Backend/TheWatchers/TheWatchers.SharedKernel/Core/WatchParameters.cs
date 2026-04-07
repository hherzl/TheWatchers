namespace TheWatchers.SharedKernel.Core;

public class WatchParameters : Dictionary<string, string>
{
    public const string IPAddress = "IPAddress";
    public const string ConnectionString = "ConnectionString";
    public const string DatabaseName = "DatabaseName";
    public const string Endpoint = "Endpoint";
    public const string HostName = "HostName";

    public WatchParameters()
    {
    }

    public WatchParameters(IDictionary<string, string> dictionary)
    {
        foreach (var entry in dictionary)
        {
            if (!ContainsKey(entry.Key))
                Add(entry.Key, entry.Value);
        }
    }
}
