using Env = TheWatcher.Domain.Core.Models.Environment;

namespace TheWatcher.Seed.Db.Seeds
{
    internal class Environments
    {
        public static IEnumerable<Env> Items
        {
            get
            {
                yield return new Env { Name = "Development" };

                yield return new Env { Name = "QA" };

                yield return new Env { Name = "Staging" };

                yield return new Env { Name = "Production" };
            }
        }
    }
}
