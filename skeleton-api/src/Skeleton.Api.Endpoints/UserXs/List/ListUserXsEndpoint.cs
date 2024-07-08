using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserXs.Queries.List;

namespace Skeleton.Api.Endpoints.UserXs.List;

public static class ListUserXsEndpoint
{
    public static void MapListUserXs(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new ListUserXsQuery();
                var userXs = await sender.Send(query, cancellationToken);

                return Results.Ok(new ListUserXsResponse(userXs));
            })
            .Produces<ListUserXsResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "List userXs" });
    }
}
