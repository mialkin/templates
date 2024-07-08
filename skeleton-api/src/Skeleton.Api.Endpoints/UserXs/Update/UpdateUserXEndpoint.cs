using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserXs.Commands.Update;

namespace Skeleton.Api.Endpoints.UserXs.Update;

public static class UpdateUserXEndpoint
{
    public static void MapUpdateUserX(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPatch(routePattern, async (
                [FromBody] UpdateUserXRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<UpdateUserXCommand>();
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok()
                    : Results.BadRequest(result.Error);
            })
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Update userX" });
    }
}
