using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Skeleton.Api.Endpoints.Users.Create;
using Skeleton.Api.Endpoints.Users.Get;
using Skeleton.Api.Endpoints.Users.List;

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

        groupBuilder.MapCreateUser("create");
        groupBuilder.MapListUsers("list");
        groupBuilder.MapGetUser("get");
    }
}
