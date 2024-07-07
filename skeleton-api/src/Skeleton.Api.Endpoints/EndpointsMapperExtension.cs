using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Skeleton.Api.Endpoints.Users.Create;
using Skeleton.Api.Endpoints.Users.Delete;
using Skeleton.Api.Endpoints.Users.Get;
using Skeleton.Api.Endpoints.Users.List;
using Skeleton.Api.Endpoints.Users.Search;
using Skeleton.Api.Endpoints.Users.Update;

namespace Skeleton.Api.Endpoints;

public static class EndpointsMapperExtension
{
    public static void MapEndpoints(this IEndpointRouteBuilder builder)
    {
        MapUserEndpoints(builder);
    }

    private static void MapUserEndpoints(IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("api/users")
            .WithTags("Users");

        groupBuilder.MapCreateUser("/");
        groupBuilder.MapGetUser("/");
        groupBuilder.MapUpdateUser("/");
        groupBuilder.MapDeleteUser("/");
        groupBuilder.MapListUsers("list");
        groupBuilder.MapSearchUsers("/search");
    }
}
