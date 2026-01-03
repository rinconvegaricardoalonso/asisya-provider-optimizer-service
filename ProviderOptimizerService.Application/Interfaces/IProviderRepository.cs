namespace ProviderOptimizerService.Application.Interfaces;

using ProviderOptimizerService.Domain.Entities;

public interface IProviderRepository
{
    IEnumerable<Provider> GetAvailable();
    IEnumerable<Provider> GetAvailableProviders(string vehicleType);
}
