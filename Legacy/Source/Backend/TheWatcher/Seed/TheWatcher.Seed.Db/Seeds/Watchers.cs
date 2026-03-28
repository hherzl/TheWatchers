using TheWatcher.Domain.Core.Models;
using TheWatcher.Watchers.MongoDB;
using TheWatcher.Watchers.PingWatcher;
using TheWatcher.Watchers.PostgreSQL;
using TheWatcher.Watchers.RabbitMQ;
using TheWatcher.Watchers.RESTfulGet;
using TheWatcher.Watchers.SqlServer;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class Watchers
    {
        public static IEnumerable<(Watcher, List<WatcherParameter>)> Items
        {
            get
            {
                yield return (new Watcher
                {
                    Name = "Ping watcher",
                    Description = "Watcher for Ping requests",
                    ClassName = typeof(PingWatcher).FullName,
                    ClassGuid = new PingWatcher().Guid,
                    AssemblyQualifiedName = typeof(PingWatcher).AssemblyQualifiedName
                }, new List<WatcherParameter>
                {
                    new WatcherParameter
                    {
                        Parameter = "IPAddress",
                        Value = "",
                        IsDefault = false
                    }
                });

                yield return (new Watcher
                {
                    Name = "RESTfulGet watcher",
                    Description = "Watcher for RESTful API",
                    ClassName = typeof(RESTfulGetWatcher).FullName,
                    ClassGuid = new RESTfulGetWatcher().Guid,
                    AssemblyQualifiedName = typeof(RESTfulGetWatcher).AssemblyQualifiedName
                }, new List<WatcherParameter>
                {
                    new WatcherParameter
                    {
                        Parameter = "Endpoint",
                        Value = "",
                        IsDefault = false
                    }
                });

                yield return (new Watcher
                {
                    Name = "SQL Server watcher",
                    Description = "Watcher for SQL Server databases",
                    ClassName = typeof(SqlServerDatabaseWatcher).FullName,
                    ClassGuid = new SqlServerDatabaseWatcher().Guid,
                    AssemblyQualifiedName = typeof(SqlServerDatabaseWatcher).AssemblyQualifiedName
                }, new List<WatcherParameter>
                {
                    new WatcherParameter
                    {
                        Parameter = "ConnectionString",
                        Value = "",
                        IsDefault = false
                    }
                });

                yield return (new Watcher
                {
                    Name = "PostgreSQL watcher",
                    Description = "Watcher for PostgreSQL databases",
                    ClassName = typeof(PostgreSQLDatabaseWatcher).FullName,
                    ClassGuid = new PostgreSQLDatabaseWatcher().Guid,
                    AssemblyQualifiedName = typeof(PostgreSQLDatabaseWatcher).AssemblyQualifiedName
                }, new List<WatcherParameter>
                {
                    new WatcherParameter
                    {
                        Parameter = "ConnectionString",
                        Value = "",
                        IsDefault = false
                    }
                });

                yield return (new Watcher
                {
                    Name = "Mongo DB watcher",
                    Description = "Watcher for Mongo DB",
                    ClassName = typeof(MongoDBWatcher).FullName,
                    ClassGuid = new MongoDBWatcher().Guid,
                    AssemblyQualifiedName = typeof(MongoDBWatcher).AssemblyQualifiedName
                }, new List<WatcherParameter>
                {
                    new WatcherParameter
                    {
                        Parameter = "DatabaseName",
                        Value = "",
                        IsDefault = false
                    }
                });

                yield return (new Watcher
                {
                    Name = "Rabbit MQ watcher",
                    Description = "Watcher for Rabbit MQ",
                    ClassName = typeof(RabbitMQWatcher).FullName,
                    ClassGuid = new RabbitMQWatcher().Guid,
                    AssemblyQualifiedName = typeof(RabbitMQWatcher).AssemblyQualifiedName
                }, new List<WatcherParameter>
                {
                    new WatcherParameter
                    {
                        Parameter = "HostName",
                        Value = "",
                        IsDefault = false
                    }
                });
            }
        }
    }
}
