using ProviderOptimizerService.Infrastructure.Persistence.Entities;

namespace ProviderOptimizerService.Infrastructure.Persistence.Seed;

public static class ProviderSeeder
{
    public static async Task SeedAsync(ProviderDbContext context)
    {
        if (context.Providers.Any())
            return;

        var providers = new List<ProviderEntity>
        {
            new ProviderEntity
            {
                Name = "Provider Norte",
                Address = "Zona Norte",
                Latitude = 7.8891,
                Longitude = -72.4967,
                IsAvailable = true,
                VehicleType = "Car",
                Rating = 4.8
            },
            new ProviderEntity
            {
                Name = "Provider Centro",
                Address = "Zona Centro",
                Latitude = 7.8939,
                Longitude = -72.5078,
                IsAvailable = true,
                VehicleType = "Car",
                Rating = 4.5
            },
            new ProviderEntity
            {
                Name = "Provider Sur",
                Address = "Zona Sur",
                Latitude = 7.8781,
                Longitude = -72.5145,
                IsAvailable = true,
                VehicleType = "Bike",
                Rating = 4.9
            },
            new ProviderEntity
            {
                Name = "Provider Ocupado",
                Address = "Zona Centro",
                Latitude = 7.8900,
                Longitude = -72.5000,
                IsAvailable = false,
                VehicleType = "Car",
                Rating = 5.0
            }
        };

        await context.Providers.AddRangeAsync(providers);
        await context.SaveChangesAsync();
    }
}
