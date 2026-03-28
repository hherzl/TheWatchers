namespace TheWatcher.API.Common.Models.Contracts
{
    public interface IResponse
    {
        string Message { get; set; }
        bool Failed { get; set; }
    }
}
