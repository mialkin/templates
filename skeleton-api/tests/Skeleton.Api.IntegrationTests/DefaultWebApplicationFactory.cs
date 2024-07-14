using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Skeleton.Api.IntegrationTests;

public class DefaultWebApplicationFactory<T> : WebApplicationFactory<T>
    where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (string.IsNullOrWhiteSpace(environment))
        {
            throw new InvalidOperationException("Environment variable 'ASPNETCORE_ENVIRONMENT' is not set");
        }

        builder.UseEnvironment(environment);
    }
}
