using TheWatcher.Library.Core;
using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Watchers.RESTfulGet
{
    public sealed class RESTfulGetWatcher : IWatcher
    {
        static readonly Guid ClassGuid = new("5A4FB948-176D-4645-A4EA-47FF6844E56A");

        public Guid Guid
            => ClassGuid;

        public string ActionName
            => "RESTfulGet";

        public async Task<WatcherResult> WatchAsync(WatcherParam parameter)
        {
            var result = new WatcherResult();

            try
            {
                using var client = new HttpClient();

                var response = await client.GetAsync(parameter.Values[WatcherParam.Endpoint]);
                response.EnsureSuccessStatusCode();

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
