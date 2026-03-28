using Microsoft.EntityFrameworkCore;
using TheWatcher.Domain.Core;

namespace TheWatcher.Seed.Db.Helpers
{
    internal static class DbContextHelper
    {
        const string ConnectionString = "Server=(local); Database=TheWatcher; Integrated Security=yes; TrustServerCertificate=true;";

        public static TheWatcherDbContext GetTheWatcherDbContext()
            => new(new DbContextOptionsBuilder<TheWatcherDbContext>().UseSqlServer(ConnectionString).Options);
    }
}
