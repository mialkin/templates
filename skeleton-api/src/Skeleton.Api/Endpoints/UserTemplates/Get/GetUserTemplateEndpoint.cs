using Microsoft.OpenApi.Models;

namespace Skeleton.Api.Endpoints.UserTemplates.Get;

public static class GetUserTemplateEndpoint
{
    public static void MapGetUserTemplate(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (Guid id, CancellationToken cancellationToken) =>
            {
                await Task.Delay(1, cancellationToken);

                var guid = Guid.NewGuid();
                return Results.Ok(new GetUserTemplateResponse(Id: guid, Name: "Name" + guid));
            })
            .Produces<GetUserTemplateResponse>()
            .WithOpenApi(operation => new OpenApiOperation(operation) { Summary = "Get userTemplate" });
    }
}
