using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.ResourcesWatches;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapResourceWatches(this WebApplication webApplication)
    {
        webApplication.MapGet("resources-watches", async ([FromServices] GetResourcesWatchesQueryHandler handler, [AsParameters] GetResourcesWatchesQuery request) =>
        {
            var value = await handler.HandleAsync(request);
            return Results.Ok(value);
        });

        return webApplication;
    }
}
