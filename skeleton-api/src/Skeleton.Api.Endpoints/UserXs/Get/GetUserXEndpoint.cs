using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.Domain;
using Skeleton.UseCases.UserXs.Queries.Get;

namespace Skeleton.Api.Endpoints.UserXs.Get;

public static class GetUserXEndpoint
{
    public static void MapGetUserX(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetUserXQuery(id);
                var maybe = await sender.Send(query, cancellationToken);

                return maybe.HasValue
                    ? Results.Ok(maybe.Value.Adapt<GetUserXResponse>())
                    : Results.BadRequest(Errors.General.NotFound());
            })
            .Produces<GetUserXResponse>()
            .Produces<Error>(StatusCodes.Status400BadRequest)
            .WithOpenApi(operation => new OpenApiOperation(operation) { Summary = "Get userX" });
    }
}
