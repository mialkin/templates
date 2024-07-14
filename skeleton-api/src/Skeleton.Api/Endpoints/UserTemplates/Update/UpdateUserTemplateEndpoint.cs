using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Skeleton.Api.Endpoints.UserTemplates.Update;

public static class UpdateUserTemplateEndpoint
{
    public static void MapUpdateUserTemplate(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPatch(routePattern, async (
                [FromBody] UpdateUserTemplateRequest request,
                CancellationToken cancellationToken) =>
            {
                await Task.Delay(1, cancellationToken);

                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Update userTemplate" });
    }
}
