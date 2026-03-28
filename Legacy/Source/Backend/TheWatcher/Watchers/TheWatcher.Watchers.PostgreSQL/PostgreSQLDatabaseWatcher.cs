using Npgsql;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watchers.PostgreSQL
{
    public sealed class PostgreSQLDatabaseWatcher : IWatcher
    {
        static readonly Guid ClassGuid = new("A7C757FC-9DA2-4563-880B-15D93693DDC6");

        public Guid Guid
            => ClassGuid;

        public string ActionName
            => "OpenDatabaseConnection";

        public async Task<WatcherResult> WatchAsync(WatcherParam parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            var result = new WatcherResult();

            using var connection = new NpgsqlConnection(parameter.Values[WatcherParam.ConnectionString]);

            try
            {
                await connection.OpenAsync();

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }
    }
}
