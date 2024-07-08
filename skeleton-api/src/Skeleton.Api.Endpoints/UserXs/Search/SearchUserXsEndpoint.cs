using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserXs.Queries.Search;

namespace Skeleton.Api.Endpoints.UserXs.Search;

public static class SearchUserXsEndpoint
{
    public static void MapSearchUserXs(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                [AsParameters] SearchUserXsRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new SearchUserXsQuery(request.Term);
                var userXs = await sender.Send(query, cancellationToken);

                return Results.Ok(new SearchUserXsResponse(userXs));
            })
            .Produces<SearchUserXsResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Search userXs" });
    }
}
