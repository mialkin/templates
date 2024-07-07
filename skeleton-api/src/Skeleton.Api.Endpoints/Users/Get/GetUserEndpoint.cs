using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.Domain;
using Skeleton.UseCases.Users.Queries.Get;

namespace Skeleton.Api.Endpoints.Users.Get;

public static class GetUserEndpoint
{
    public static void MapGetUser(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetUserQuery(id);
                var maybe = await sender.Send(query, cancellationToken);

                return maybe.HasValue
                    ? Results.Ok(maybe.Value.Adapt<GetUserResponse>())
                    : Results.BadRequest(Errors.General.NotFound());
            })
            .Produces<GetUserResponse>()
            .Produces<Error>(StatusCodes.Status400BadRequest)
            .WithOpenApi(operation => new OpenApiOperation(operation) { Summary = "Get user" });
    }
}
