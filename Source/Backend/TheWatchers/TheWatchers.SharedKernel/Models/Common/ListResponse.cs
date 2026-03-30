namespace TheWatchers.SharedKernel.Models.Common;

public record ListResponse<TModel> : Response where TModel : class
{
    public ListResponse(IList<TModel> model)
    {
        Model = model;
    }

    IList<TModel> Model { get; set; }
}
