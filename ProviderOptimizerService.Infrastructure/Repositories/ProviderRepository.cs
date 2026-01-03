using ProviderOptimizerService.Application.Interfaces;
using ProviderOptimizerService.Domain.Entities;
using ProviderOptimizerService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ProviderOptimizerService.Infrastructure.Repositories;

public class ProviderRepository : IProviderRepository
{
    private readonly ProviderDbContext _context;

    public ProviderRepository(ProviderDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Provider> GetAvailable()
    {
        return _context.Providers
            .Where(p =>
                p.IsAvailable)
            .AsNoTracking()
            .Select(p => new Provider(
                p.Id,
                p.Name,
                p.Address,
                p.Latitude,
                p.Longitude,
                p.IsAvailable,
                p.VehicleType,
                p.Rating))
            .ToList();
    }

    public IEnumerable<Provider> GetAvailableProviders(string vehicleType)
    {
        return _context.Providers
            .Where(p =>
                p.IsAvailable &&
                p.VehicleType.ToUpper() == vehicleType.ToUpper())
            .AsNoTracking()
            .Select(p => new Provider(
                p.Id,
                p.Name,
                p.Address,
                p.Latitude,
                p.Longitude,
                p.IsAvailable,
                p.VehicleType,
                p.Rating))
            .ToList();
    }
}
