namespace TheWatcher.Library.Core
{
    public class WatcherParam
    {
        public const string IPAddress = "IPAddress";
        public const string ConnectionString = "ConnectionString";
        public const string DatabaseName = "DatabaseName";
        public const string Endpoint = "Endpoint";
        public const string HostName = "HostName";

        public WatcherParam()
        {
            Values = new Dictionary<string, string>();
        }

        public WatcherParam(IDictionary<string, string> dictionary)
        {
            Values = dictionary;
        }

        public IDictionary<string, string> Values { get; set; }
    }
}
