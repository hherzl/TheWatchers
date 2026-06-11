namespace TheWatchers.SharedKernel.Models.Common;

public record CreatedResponse<TId>
{
    public CreatedResponse()
    {
    }

    public CreatedResponse(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }
}
