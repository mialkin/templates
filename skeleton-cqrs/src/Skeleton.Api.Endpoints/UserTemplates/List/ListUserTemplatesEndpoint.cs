using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserTemplates.Queries.List;

namespace Skeleton.Api.Endpoints.UserTemplates.List;

public static class ListUserTemplatesEndpoint
{
    public static void MapListUserTemplates(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new ListUserTemplatesQuery();
                var userTemplates = await sender.Send(query, cancellationToken);

                return Results.Ok(new ListUserTemplatesResponse(userTemplates));
            })
            .Produces<ListUserTemplatesResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "List userTemplates" });
    }
}
