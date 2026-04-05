using RabbitMQ.Client;
using TheWatchers.SharedKernel.Core;

namespace TheWatchers.Watchers.RabbitMQ;

public sealed class RabbitMQWatcher : IWatcher
{
    static readonly Guid ClassGuid = new("EC0CAAF2-436C-4FD5-AEE3-7BD8E27F714B");

    public Guid Guid
        => ClassGuid;

    public string ActionName
        => "CreateBrokerConnection";

    public async Task<WatcherResult> WatchAsync(WatcherParam parameter)
    {
        ArgumentNullException.ThrowIfNull(parameter);

        var result = new WatcherResult();

        try
        {
            var factory = new ConnectionFactory
            {
                HostName = parameter.Values[WatcherParam.HostName]
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            result.IsSuccess = true;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message;
            result.ErrorMessage = ex.ToString();
        }

        return await Task.FromResult(result);
    }
}
