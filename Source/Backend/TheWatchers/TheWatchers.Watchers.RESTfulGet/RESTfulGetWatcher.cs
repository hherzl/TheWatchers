using TheWatchers.SharedKernel.Core;

namespace TheWatchers.Watchers.RESTfulGet;

public sealed class RESTfulGetWatcher : IWatcher
{
    static readonly Guid ClassGuid = new("5A4FB948-176D-4645-A4EA-47FF6844E56A");

    public Guid Guid
        => ClassGuid;

    public string ActionName
        => "RESTful-GET";

    public async Task<WatchResult> WatchAsync(WatchParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        var result = new WatchResult();

        try
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(parameters[WatchParameters.Endpoint]);
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
