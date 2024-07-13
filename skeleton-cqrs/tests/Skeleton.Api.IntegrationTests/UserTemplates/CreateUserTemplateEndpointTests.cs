namespace Skeleton.Api.IntegrationTests.UserTemplates;

public class CreateUserTemplateEndpointTests(DefaultWebApplicationFactory<Program> factory)
    : IClassFixture<DefaultWebApplicationFactory<Program>>
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var client = factory.CreateClient();
    }
}
