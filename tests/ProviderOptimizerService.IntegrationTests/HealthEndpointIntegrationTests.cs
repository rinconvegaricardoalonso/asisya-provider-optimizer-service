using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

using ProviderOptimizerService.Api;

namespace ProviderOptimizerService.IntegrationTests;

[Trait("Category", "Integration")]
public class HealthEndpointIntegrationTests 
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public HealthEndpointIntegrationTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HealthEndpoint_ShouldReturn200()
    {
        var response = await _client.GetAsync("/providers/available");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
