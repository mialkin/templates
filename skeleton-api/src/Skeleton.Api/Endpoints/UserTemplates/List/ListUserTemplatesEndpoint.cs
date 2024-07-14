using Microsoft.OpenApi.Models;

namespace Skeleton.Api.Endpoints.UserTemplates.List;

public static class ListUserTemplatesEndpoint
{
    public static void MapListUserTemplates(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                CancellationToken cancellationToken) =>
            {
                await Task.Delay(1, cancellationToken);

                return Results.Ok(new ListUserTemplatesResponse(new[]
                {
                    "UserTemplate" + Guid.NewGuid(),
                    "UserTemplate" + Guid.NewGuid(),
                    "UserTemplate" + Guid.NewGuid()
                }));
            })
            .Produces<ListUserTemplatesResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "List userTemplates" });
    }
}
