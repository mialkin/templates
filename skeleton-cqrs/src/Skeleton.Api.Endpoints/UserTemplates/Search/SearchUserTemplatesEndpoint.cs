using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Skeleton.UseCases.UserTemplates.Queries.Search;

namespace Skeleton.Api.Endpoints.UserTemplates.Search;

public static class SearchUserTemplatesEndpoint
{
    public static void MapSearchUserTemplates(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                [AsParameters] SearchUserTemplatesRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new SearchUserTemplatesQuery(request.Term);
                var userTemplates = await sender.Send(query, cancellationToken);

                return Results.Ok(new SearchUserTemplatesResponse(userTemplates));
            })
            .Produces<SearchUserTemplatesResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Search userTemplates" });
    }
}
