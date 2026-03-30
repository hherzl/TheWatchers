namespace TheWatchers.SharedKernel.Core;

public interface IWatcher
{
    Guid Guid { get; }

    string ActionName { get; }

    Task<WatcherResult> WatchAsync(WatcherParam parameter);
}
