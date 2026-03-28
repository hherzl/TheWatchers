using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class ResourceCategories
    {
        public static IEnumerable<ResourceCategory> Items
        {
            get
            {
                yield return new ResourceCategory
                {
                    Name = "Server",
                    WatcherId = 1
                };

                yield return new ResourceCategory
                {
                    Name = "RESTful API",
                    WatcherId = 2
                };

                yield return new ResourceCategory
                {
                    Name = "SQL Server Database",
                    WatcherId = 3
                };

                yield return new ResourceCategory
                {
                    Name = "PostgreSQL Database",
                    WatcherId = 4
                };

                yield return new ResourceCategory
                {
                    Name = "MongoDB Database",
                    WatcherId = 5
                };

                yield return new ResourceCategory
                {
                    Name = "Broker",
                    WatcherId = 6
                };
            }
        }
    }
}
