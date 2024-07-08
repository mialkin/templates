using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserTemplates.Commands.Update;

namespace Skeleton.Api.Endpoints.UserTemplates.Update;

public static class UpdateUserTemplateEndpoint
{
    public static void MapUpdateUserTemplate(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPatch(routePattern, async (
                [FromBody] UpdateUserTemplateRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<UpdateUserTemplateCommand>();
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok()
                    : Results.BadRequest(result.Error);
            })
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Update userTemplate" });
    }
}
