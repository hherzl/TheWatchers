using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class Resources
    {
        public static IEnumerable<Resource> Items
        {
            get
            {
                yield return new Resource
                {
                    Name = "Watcher Sample for Default gateway",
                    ResourceCategoryId = 1
                };

                yield return new Resource
                {
                    Name = "Watcher Sample for RESTful API",
                    ResourceCategoryId = 2
                };

                yield return new Resource
                {
                    Name = "SQL Server Database Watcher Sample",
                    ResourceCategoryId = 3
                };

                yield return new Resource
                {
                    Name = "Mongo DB Watcher Sample",
                    ResourceCategoryId = 5
                };

                yield return new Resource
                {
                    Name = "Rabbit MQ Watcher Sample",
                    ResourceCategoryId = 6
                };
            }
        }
    }
}
