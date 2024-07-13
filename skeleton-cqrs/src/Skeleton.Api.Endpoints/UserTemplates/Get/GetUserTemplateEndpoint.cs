using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.Domain;
using Skeleton.UseCases.UserTemplates.Queries.Get;

namespace Skeleton.Api.Endpoints.UserTemplates.Get;

public static class GetUserTemplateEndpoint
{
    public static void MapGetUserTemplate(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetUserTemplateQuery(id);
                var maybe = await sender.Send(query, cancellationToken);

                return maybe.HasValue
                    ? Results.Ok(maybe.Value.Adapt<GetUserTemplateResponse>())
                    : Results.BadRequest(Errors.General.NotFound());
            })
            .Produces<GetUserTemplateResponse>()
            .Produces<Error>(StatusCodes.Status400BadRequest)
            .WithOpenApi(operation => new OpenApiOperation(operation) { Summary = "Get userTemplate" });
    }
}
