using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.Users.Commands.CreateUser;

namespace Skeleton.Api.Endpoints.Users.Create;

public static class CreateUserEndpoint
{
    public static void MapCreateUser(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, async (
                [FromBody] CreateUserRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<CreateUserCommand>();
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value.Adapt<CreateUserResponse>())
                    : Results.BadRequest(result.Error);
            })
            .WithOpenApi(operation => new OpenApiOperation(operation) { Summary = "Create user" });
    }
}
