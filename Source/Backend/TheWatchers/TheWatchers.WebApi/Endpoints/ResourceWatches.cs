using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.ResourcesWatches;

namespace TheWatchers.WebApi.Endpoints;

public static class ResourceWatches
{
    public static WebApplication MapResourceWatches(this WebApplication webApplication)
    {
        webApplication.MapGet("resources-watches", async ([FromServices] GetResourcesWatchesQueryHandler queryHandler, [AsParameters] GetResourcesWatchesQuery request) =>
        {
            var value = await queryHandler.HandleAsync(request);
            return Results.Ok(value);
        });

        return webApplication;
    }
}
