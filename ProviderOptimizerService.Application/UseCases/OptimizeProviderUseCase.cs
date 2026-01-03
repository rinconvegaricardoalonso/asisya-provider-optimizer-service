using ProviderOptimizerService.Application.DTOs;
using ProviderOptimizerService.Application.Interfaces;
using ProviderOptimizerService.Domain.Services;

namespace ProviderOptimizerService.Application.UseCases;

public class OptimizeProviderUseCase
{
    private const double AverageSpeedKmH = 40;

    private readonly IProviderRepository _repository;

    public OptimizeProviderUseCase(IProviderRepository repository)
    {
        _repository = repository;
    }

    public OptimizeProviderResult Execute(
        double vehicleLat,
        double vehicleLon,
        string vehicleType)
    {
        var providers = _repository.GetAvailableProviders(vehicleType);

        var bestProvider = providers
            .Select(provider =>
            {
                var distance = DistanceCalculator.CalculateDistance(
                    vehicleLat,
                    vehicleLon,
                    provider.Latitude,
                    provider.Longitude);

                var etaMinutes = (int)Math.Round((distance / AverageSpeedKmH) * 60);

                var score =
                    (distance * 0.6) +
                    (etaMinutes * 0.3) -
                    (provider.Rating * 0.1);

                return new
                {
                    Provider = provider,
                    Distance = distance,
                    Eta = etaMinutes,
                    Score = score
                };
            })
            .OrderBy(x => x.Score)
            .First();

        return new OptimizeProviderResult
        {
            ProviderId = bestProvider.Provider.Id,
            Address = bestProvider.Provider.Address,
            DistanceKm = Math.Round(bestProvider.Distance, 2),
            EtaMinutes = bestProvider.Eta,
            IsAvailable = bestProvider.Provider.IsAvailable
        };
    }
}
