using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class ResourceWatches
    {
        public static IEnumerable<(ResourceWatch, List<ResourceWatchParameter>)> Items
        {
            get
            {
                // Ping

                yield return (new ResourceWatch
                {
                    ResourceId = 1,
                    EnvironmentId = 1,
                    Interval = 10000,
                    WatchCount = 0
                }, new List<ResourceWatchParameter>
                {
                    new()
                    {
                        ResourceWatchId = 1,
                        Parameter = "IPAddress",
                        Value = " 192.168.1.1"
                    }
                });

                // RESTful API

                yield return (new ResourceWatch
                {
                    ResourceId = 2,
                    EnvironmentId = 1,
                    Interval = 10000,
                    WatchCount = 0
                }, new List<ResourceWatchParameter>
                {
                    new()
                    {
                        ResourceWatchId = 2,
                        Parameter = "Endpoint",
                        Value = "https://api.ipify.org?format=json"
                    }
                });

                // SQL Server

                yield return (new ResourceWatch
                {
                    ResourceId = 3,
                    EnvironmentId = 1,
                    Interval = 15000,
                    WatchCount = 0
                }, new List<ResourceWatchParameter>
                {
                    new()
                    {
                        ResourceWatchId = 3,
                        Parameter = "ConnectionString",
                        Value = "Server=(local); Database=TheWatcher; Integrated Security=yes; TrustServerCertificate=true;"
                    }
                });

                // Mongo DB

                yield return (new ResourceWatch
                {
                    ResourceId = 4,
                    EnvironmentId = 1,
                    Interval = 20000,
                    WatchCount = 0
                }, new List<ResourceWatchParameter>
                {
                    new()
                    {
                        ResourceWatchId = 4,
                        Parameter = "ConnectionString",
                        Value = "mongodb://localhost:27017"
                    },
                    new()
                    {
                        ResourceWatchId = 4,
                        Parameter = "DatabaseName",
                        Value = "TheWatcher"
                    }
                });

                // RabbitMQ

                yield return (new ResourceWatch
                {
                    ResourceId = 5,
                    EnvironmentId = 1,
                    Interval = 30000,
                    WatchCount = 0
                }, new List<ResourceWatchParameter>
                {
                    new()
                    {
                        ResourceWatchId = 5,
                        Parameter = "HostName",
                        Value = "localhost"
                    }
                });
            }
        }
    }
}
