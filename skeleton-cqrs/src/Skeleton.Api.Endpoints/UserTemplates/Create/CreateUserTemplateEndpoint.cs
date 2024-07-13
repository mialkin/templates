using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserTemplates.Commands.Create;

namespace Skeleton.Api.Endpoints.UserTemplates.Create;

public static class CreateUserTemplateEndpoint
{
    public static void MapCreateUserTemplate(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, async (
                [FromBody] CreateUserTemplateRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<CreateUserTemplateCommand>();
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value.Adapt<CreateUserTemplateResponse>())
                    : Results.BadRequest(result.Error);
            })
            .Produces<CreateUserTemplateResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Create userTemplate" });
    }
}
