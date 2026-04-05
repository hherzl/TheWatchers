using MongoDB.Driver;
using TheWatchers.SharedKernel.Core;

namespace TheWatchers.Watchers.MongoDB;

public sealed class MongoDBWatcher : IWatcher
{
    static readonly Guid ClassGuid = new("5F766F68-1554-4F9C-9098-61CA3BA5A0D2");

    public Guid Guid
        => ClassGuid;

    public string ActionName
        => "OpenNoSqlDbConnection";

    public async Task<WatcherResult> WatchAsync(WatcherParam parameter)
    {
        ArgumentNullException.ThrowIfNull(parameter);

        var result = new WatcherResult();

        try
        {
            var client = new MongoClient(parameter.Values[WatcherParam.ConnectionString]);

            await client.StartSessionAsync();

            var database = client.GetDatabase(parameter.Values[WatcherParam.DatabaseName]);

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
