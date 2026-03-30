namespace TheWatchers.SharedKernel.Models.Common;

public record SingleResponse<TModel> : Response where TModel : class
{
    public SingleResponse(TModel model)
    {
        Model = model;
    }

    TModel Model { get; set; }
}
