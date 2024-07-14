using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Skeleton.Api.Endpoints.UserTemplates.Delete;

public static class DeleteUserTemplateEndpoint
{
    public static void MapDeleteUserTemplate(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapDelete(routePattern, async (
                [FromBody] DeleteUserTemplateRequest request,
                CancellationToken cancellationToken) =>
            {
                await Task.Delay(1, cancellationToken);

                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Delete userTemplate" });
    }
}
