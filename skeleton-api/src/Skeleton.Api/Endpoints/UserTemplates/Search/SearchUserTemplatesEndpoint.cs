using Microsoft.OpenApi.Models;

namespace Skeleton.Api.Endpoints.UserTemplates.Search;

public static class SearchUserTemplatesEndpoint
{
    public static void MapSearchUserTemplates(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                [AsParameters] SearchUserTemplatesRequest request,
                CancellationToken cancellationToken) =>
            {
                await Task.Delay(1, cancellationToken);

                return Results.Ok(new SearchUserTemplatesResponse(new[]
                {
                    "UserTemplate" + Guid.NewGuid(),
                    "UserTemplate" + Guid.NewGuid(),
                    "UserTemplate" + Guid.NewGuid()
                }));
            })
            .Produces<SearchUserTemplatesResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Search userTemplates" });
    }
}
