using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Skeleton.Api.Endpoints.Users;

namespace Skeleton.Api.Endpoints;

public static class ApplicationEndpoints
{
    public static void MapApplicationEndpoints(this IEndpointRouteBuilder builder)
    {
        MapUsersEndpoints(builder);
    }

    private static void MapUsersEndpoints(IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("api/users")
            .WithTags("Users");

        groupBuilder.MapCreateUser("create");
    }
}