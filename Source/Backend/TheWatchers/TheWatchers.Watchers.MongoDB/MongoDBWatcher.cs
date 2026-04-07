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

    public async Task<WatchResult> WatchAsync(WatchParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        var result = new WatchResult();

        try
        {
            var client = new MongoClient(parameters.Values[WatchParameters.ConnectionString]);

            await client.StartSessionAsync();

            var database = client.GetDatabase(parameters.Values[WatchParameters.DatabaseName]);

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
