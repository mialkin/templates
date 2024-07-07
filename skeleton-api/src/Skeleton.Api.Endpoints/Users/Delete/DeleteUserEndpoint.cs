using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.Users.Commands.Delete;

namespace Skeleton.Api.Endpoints.Users.Delete;

public static class DeleteUserEndpoint
{
    public static void MapDeleteUser(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapDelete(routePattern, async (
                [FromBody] DeleteUserRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteUserCommand(request.Id);
                await sender.Send(command, cancellationToken);

                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Delete user" });
    }
}
