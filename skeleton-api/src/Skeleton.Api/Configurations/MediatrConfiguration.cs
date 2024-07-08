using Skeleton.UseCases.UserXs.Commands.Create;

namespace Skeleton.Api.Configurations;

public static class MediatrConfiguration
{
    public static void ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<CreateUserXCommand>());
    }
}
