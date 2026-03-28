using System.Data.SqlClient;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watchers.SqlServer
{
    public sealed class SqlServerDatabaseWatcher : IWatcher
    {
        static readonly Guid ClassGuid = new("A1059C4E-1615-49EB-993D-274458DD212B");

        public Guid Guid
            => ClassGuid;

        public string ActionName
            => "OpenDatabaseConnection";

        public async Task<WatcherResult> WatchAsync(WatcherParam parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            var result = new WatcherResult();

            using var connection = new SqlConnection(parameter.Values[WatcherParam.ConnectionString]);

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
