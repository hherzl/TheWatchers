namespace TheWatchers.SharedKernel.Core;

public interface IWatchResult
{
    bool IsSuccess { get; set; }
    DateTime LastWatch { get; set; }
    string Message { get; set; }
    string ErrorMessage { get; set; }
}
