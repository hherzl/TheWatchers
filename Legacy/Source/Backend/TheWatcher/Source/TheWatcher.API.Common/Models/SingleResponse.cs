using TheWatcher.API.Common.Models.Contracts;

namespace TheWatcher.API.Common.Models
{
    public record SingleResponse<TModel> : Response, ISingleResponse<TModel>
    {
        public SingleResponse()
        {
        }

        public SingleResponse(TModel model)
        {
            Model = model;
        }

        public TModel Model { get; set; }
    }
}
