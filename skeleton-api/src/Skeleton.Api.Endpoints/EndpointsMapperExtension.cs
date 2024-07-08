using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Skeleton.Api.Endpoints.UserTemplates.Create;
using Skeleton.Api.Endpoints.UserTemplates.Delete;
using Skeleton.Api.Endpoints.UserTemplates.Get;
using Skeleton.Api.Endpoints.UserTemplates.List;
using Skeleton.Api.Endpoints.UserTemplates.Search;
using Skeleton.Api.Endpoints.UserTemplates.Update;

namespace Skeleton.Api.Endpoints;

public static class EndpointsMapperExtension
{
    public static void MapEndpoints(this IEndpointRouteBuilder builder)
    {
        MapUserTemplateEndpoints(builder);
    }

    private static void MapUserTemplateEndpoints(IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("api/userTemplates")
            .WithTags("UserTemplates");

        groupBuilder.MapCreateUserTemplate("/");
        groupBuilder.MapGetUserTemplate("/");
        groupBuilder.MapUpdateUserTemplate("/");
        groupBuilder.MapDeleteUserTemplate("/");
        groupBuilder.MapListUserTemplates("list");
        groupBuilder.MapSearchUserTemplates("/search");
    }
}
