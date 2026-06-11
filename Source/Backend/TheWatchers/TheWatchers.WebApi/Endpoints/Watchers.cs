using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.Watchers;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapWatchers(this WebApplication webApplication)
    {
        webApplication.MapGet("watchers", async ([FromServices] GetWatchersQueryHandler handler, [AsParameters] GetWatchersQuery request) =>
        {
            var result = await handler.HandleAsync(request);
            return Results.Ok(result);
        });

        webApplication.MapGet("watchers/create-viewbag", async ([FromServices] GetCreateWatcherViewBagQueryHandler handler) =>
        {
            var result = await handler.HandleAsync(new GetCreateWatcherViewBagQuery());
            return Results.Ok(result);
        });

        webApplication.MapGet("watchers/{id}", async ([FromServices] GetWatcherQueryHandler handler, short id) =>
        {
            var result = await handler.HandleAsync(new GetWatcherQuery(id));
            return result == null ? Results.NotFound() : Results.Ok(result);
        });

        webApplication.MapPost("watchers", async ([FromServices] CreateWatcherCommandHandler handler, CreateWatcherCommand request) =>
        {
            var result = await handler.HandleAsync(request);
            return Results.Created($"/watchers/{result.Id}", result);
        });

        return webApplication;
    }
}
