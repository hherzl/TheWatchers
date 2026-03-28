using System.Net.NetworkInformation;
using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watchers.PingWatcher
{
    public sealed class PingWatcher : IWatcher
    {
        static readonly Guid ClassGuid = new("75B0AD20-A454-41E9-9FDA-AD065A7A95DD");

        public Guid Guid
            => ClassGuid;

        public string ActionName
            => "Ping";

        public async Task<WatcherResult> WatchAsync(WatcherParam parameter)
        {
            var result = new WatcherResult();

            try
            {
                var reply = await new Ping().SendPingAsync(parameter.Values[WatcherParam.IPAddress]);

                result.IsSuccess = reply.Status == IPStatus.Success;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.ErrorMessage = ex.ToString();
            }

            return result;
        }
    }
}
