using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.Resources;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapResources(this WebApplication webApplication)
    {
        webApplication.MapGet("resources", async ([FromServices] GetResourcesQueryHandler queryHandler, [AsParameters] GetResourcesQuery request) =>
        {
            var value = await queryHandler.HandleAsync(request);
            return Results.Ok(value);
        });

        webApplication.MapGet("resources/{id}", async ([FromServices] GetResourceQueryHandler queryHandler, int id) =>
        {
            var value = await queryHandler.HandleAsync(new GetResourceQuery(id));
            return Results.Ok(value);
        });

        return webApplication;
    }
}
