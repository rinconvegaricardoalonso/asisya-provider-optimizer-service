using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;

using ProviderOptimizerService.Application.UseCases;
using ProviderOptimizerService.Application.DTOs;
using ProviderOptimizerService.Application.Interfaces;
using ProviderOptimizerService.Domain.Entities;

namespace ProviderOptimizerService.Application.Tests;

public class OptimizeProviderUseCaseTests
{
    [Fact]
    public void Execute_ShouldReturnBestProvider_WhenProvidersAreAvailable()
    {
        // Arrange
        var repositoryMock = new Mock<IProviderRepository>();

        var providers = new List<Provider>
        {
            new Provider
            (
                id: 1,
                name: "fgfdgfg",
                address: "Provider A",
                latitude: 4.65,
                longitude: -74.05,
                isAvailable: true,
                vehicleType: "CAR",
                rating: 4.5
            ),
            new Provider
            (
                id: 2,
                name: "fgfdgfg",
                address: "Provider B",
                latitude: 4.70,
                longitude: -74.10,
                isAvailable: true,
                vehicleType: "CAR",
                rating: 4.5
            )
        };

        repositoryMock
            .Setup(r => r.GetAvailableProviders("CAR"))
            .Returns(providers);

        var useCase = new OptimizeProviderUseCase(repositoryMock.Object);

        // Act
        var result = useCase.Execute(
            vehicleLat: 4.64,
            vehicleLon: -74.04,
            vehicleType: "CAR"
        );

        // Assert
        result.Should().NotBeNull();
        result.IsAvailable.Should().BeTrue();
        result.ProviderId.Should().Be(1);
        result.Address.Should().Be("Provider A");
        result.DistanceKm.Should().BeGreaterThan(0);
        result.EtaMinutes.Should().BeGreaterThan(0);
    }
}
