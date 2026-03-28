using TheWatcher.API.Common.Models.Contracts;

namespace TheWatcher.API.Common.Models
{
    public record ListResponse<TModel> : Response, IListResponse<TModel>
    {
        public ListResponse()
        {
        }

        public ListResponse(IEnumerable<TModel> model)
        {
            Model = model;
        }

        public IEnumerable<TModel> Model { get; set; }
    }
}
