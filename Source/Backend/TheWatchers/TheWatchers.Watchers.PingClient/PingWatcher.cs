using System.Net.NetworkInformation;
using TheWatchers.SharedKernel.Core;

namespace TheWatchers.Watchers.PingClient;

public sealed class PingWatcher : IWatcher
{
    static readonly Guid ClassGuid = new("75B0AD20-A454-41E9-9FDA-AD065A7A95DD");

    public Guid Guid
        => ClassGuid;

    public string ActionName
        => "Ping";

    public async Task<WatchResult> WatchAsync(WatchParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        var result = new WatchResult();

        try
        {
            var reply = await new Ping().SendPingAsync(parameters.Values[WatchParameters.IPAddress]);
            result.IsSuccess = reply.Status == IPStatus.Success;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.ErrorMessage = ex.ToString();
        }

        return result;
    }
}
