using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Skeleton.Api.Endpoints.UserXs.Create;
using Skeleton.Api.Endpoints.UserXs.Delete;
using Skeleton.Api.Endpoints.UserXs.Get;
using Skeleton.Api.Endpoints.UserXs.List;
using Skeleton.Api.Endpoints.UserXs.Search;
using Skeleton.Api.Endpoints.UserXs.Update;

namespace Skeleton.Api.Endpoints;

public static class EndpointsMapperExtension
{
    public static void MapEndpoints(this IEndpointRouteBuilder builder)
    {
        MapUserXEndpoints(builder);
    }

    private static void MapUserXEndpoints(IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("api/userXs")
            .WithTags("UserXs");

        groupBuilder.MapCreateUserX("/");
        groupBuilder.MapGetUserX("/");
        groupBuilder.MapUpdateUserX("/");
        groupBuilder.MapDeleteUserX("/");
        groupBuilder.MapListUserXs("list");
        groupBuilder.MapSearchUserXs("/search");
    }
}
