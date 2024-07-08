using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserXs.Commands.Delete;

namespace Skeleton.Api.Endpoints.UserXs.Delete;

public static class DeleteUserXEndpoint
{
    public static void MapDeleteUserX(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapDelete(routePattern, async (
                [FromBody] DeleteUserXRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteUserXCommand(request.Id);
                await sender.Send(command, cancellationToken);

                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Delete userX" });
    }
}
