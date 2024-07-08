using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserTemplates.Commands.Delete;

namespace Skeleton.Api.Endpoints.UserTemplates.Delete;

public static class DeleteUserTemplateEndpoint
{
    public static void MapDeleteUserTemplate(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapDelete(routePattern, async (
                [FromBody] DeleteUserTemplateRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteUserTemplateCommand(request.Id);
                await sender.Send(command, cancellationToken);

                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Delete userTemplate" });
    }
}
