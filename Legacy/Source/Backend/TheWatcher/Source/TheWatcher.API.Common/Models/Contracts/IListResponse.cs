namespace TheWatcher.API.Common.Models.Contracts
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
