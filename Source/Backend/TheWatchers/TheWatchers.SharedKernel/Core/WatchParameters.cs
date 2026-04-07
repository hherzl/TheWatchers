namespace TheWatchers.SharedKernel.Core;

public class WatchParameters
{
    public const string IPAddress = "IPAddress";
    public const string ConnectionString = "ConnectionString";
    public const string DatabaseName = "DatabaseName";
    public const string Endpoint = "Endpoint";
    public const string HostName = "HostName";

    public WatchParameters()
    {
        Values = new Dictionary<string, string>();
    }

    public WatchParameters(IDictionary<string, string> dictionary)
    {
        Values = dictionary;
    }

    public IDictionary<string, string> Values { get; set; }
}
