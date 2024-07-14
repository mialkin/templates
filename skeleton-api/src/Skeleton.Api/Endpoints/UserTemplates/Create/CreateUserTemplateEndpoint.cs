using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Skeleton.Api.Endpoints.UserTemplates.Create;

public static class CreateUserTemplateEndpoint
{
    public static void MapCreateUserTemplate(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, async (
                [FromBody] CreateUserTemplateRequest request,
                CancellationToken cancellationToken) =>
            {
                await Task.Delay(1, cancellationToken);

                return Results.Ok(new CreateUserTemplateResponse(Guid.NewGuid()));
            })
            .Produces<CreateUserTemplateResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Create userTemplate" });
    }
}
