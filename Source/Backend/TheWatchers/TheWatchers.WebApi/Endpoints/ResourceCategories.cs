using Microsoft.AspNetCore.Mvc;
using TheWatchers.Application.Features.ResourcesCategories;

namespace TheWatchers.WebApi.Endpoints;

public static partial class Mappings
{
    public static WebApplication MapResourceCategories(this WebApplication webApplication)
    {
        webApplication.MapGet("resources-categories", async ([FromServices] GetResourcesCategoriesQueryHandler handler, [AsParameters] GetResourcesCategoriesQuery request) =>
        {
            var value = await handler.HandleAsync(request);
            return Results.Ok(value);
        });

        webApplication.MapGet("resources-categories/{id}", async ([FromServices] GetResourceCategoryQueryHandler handler, short id) =>
        {
            var value = await handler.HandleAsync(new GetResourceCategoryQuery(id));
            return value == null ? Results.NotFound() : Results.Ok(value);
        });

        return webApplication;
    }
}
