namespace TheWatcher.API.Common.Models.Contracts
{
    public interface ISingleResponse<TModel>
    {
        TModel Model { get; }
    }
}
