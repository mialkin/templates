using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.Users.Queries.Search;

namespace Skeleton.Api.Endpoints.Users.Search;

public static class SearchUsersEndpoint
{
    public static void MapSearchUsers(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                [AsParameters] SearchUsersRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new SearchUsersQuery(request.Term);
                var users = await sender.Send(query, cancellationToken);

                return Results.Ok(new SearchUsersResponse(users));
            })
            .Produces<SearchUsersResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Search users" });
    }
}
