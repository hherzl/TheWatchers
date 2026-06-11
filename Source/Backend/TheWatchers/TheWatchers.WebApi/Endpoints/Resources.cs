using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.Resources;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapResources(this WebApplication webApplication)
    {
        webApplication.MapGet("resources", async ([FromServices] GetResourcesQueryHandler handler, [AsParameters] GetResourcesQuery request) =>
        {
            var value = await handler.HandleAsync(request);
            return Results.Ok(value);
        });

        webApplication.MapGet("resources/{id}", async ([FromServices] GetResourceQueryHandler handler, int id) =>
        {
            var value = await handler.HandleAsync(new GetResourceQuery(id));
            return value == null ? Results.NotFound() : Results.Ok(value);
        });

        return webApplication;
    }
}
