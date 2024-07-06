using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.Domain;
using Skeleton.UseCases.Users.Queries.GetById;

namespace Skeleton.Api.Endpoints.Users.GetById;

public static class GetUserByIdEndpoint
{
    public static void MapGetUserById(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetUserByIdQuery(id);
                var maybe = await sender.Send(query, cancellationToken);

                return maybe.HasValue
                    ? Results.Ok(maybe.Value.Adapt<GetUserByIdResponse>())
                    : Results.BadRequest(Errors.General.NotFound(id));
            })
            .Produces<GetUserByIdResponse>()
            .Produces<Error>(StatusCodes.Status400BadRequest)
            .WithOpenApi(operation => new OpenApiOperation(operation) { Summary = "Get user by ID" });
    }
}
