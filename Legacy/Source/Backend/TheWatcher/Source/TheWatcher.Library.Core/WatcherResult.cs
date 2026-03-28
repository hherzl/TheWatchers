using TheWatcher.Library.Core.Contracts;

namespace TheWatcher.Library.Core
{
    public class WatcherResult : IWatcherResult
    {
        public WatcherResult()
        {
            LastWatch = DateTime.Now;
        }

        public bool IsSuccess { get; set; }
        public DateTime LastWatch { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
