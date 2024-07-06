using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.Users.Queries.ListUsers;

namespace Skeleton.Api.Endpoints.Users.List;

public static class ListUsersEndpoint
{
    public static void MapListUsers(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new ListUsersQuery();
                var users = await sender.Send(query, cancellationToken);

                return Results.Ok(new ListUsersResponse(users));
            })
            .Produces<ListUsersResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "List users" });
    }
}
