namespace TheWatchers.SharedKernel.Core;

public class WatchResult : IWatchResult
{
    public WatchResult()
    {
        IsSuccess = false;
        LastWatch = DateTime.Now;
    }

    public bool IsSuccess { get; set; }
    public DateTime LastWatch { get; set; }
    public string Message { get; set; }
    public string ErrorMessage { get; set; }
}
