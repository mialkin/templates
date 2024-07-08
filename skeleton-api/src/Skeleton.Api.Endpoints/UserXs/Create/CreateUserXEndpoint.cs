using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserXs.Commands.Create;

namespace Skeleton.Api.Endpoints.UserXs.Create;

public static class CreateUserXEndpoint
{
    public static void MapCreateUserX(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, async (
                [FromBody] CreateUserXRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<CreateUserXCommand>();
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value.Adapt<CreateUserXResponse>())
                    : Results.BadRequest(result.Error);
            })
            .Produces<CreateUserXResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Create userX" });
    }
}
