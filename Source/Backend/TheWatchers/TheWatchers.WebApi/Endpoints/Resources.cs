using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.Resources;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapResources(this WebApplication webApplication)
    {
        webApplication.MapGet("resources", async ([FromServices] GetResourcesQueryHandler requestHandler, [AsParameters] GetResourcesQuery request) =>
        {
            var value = await requestHandler.HandleAsync(request);
            return Results.Ok(value);
        });

        webApplication.MapGet("resources/{id}", async ([FromServices] GetResourceQueryHandler requestHandler, int id) =>
        {
            var value = await requestHandler.HandleAsync(new GetResourceQuery(id));
            if (value == null)
                return Results.NotFound();

            return Results.Ok(value);
        });

        return webApplication;
    }
}
