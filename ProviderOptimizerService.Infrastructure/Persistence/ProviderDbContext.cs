using Microsoft.EntityFrameworkCore;

using ProviderOptimizerService.Infrastructure.Persistence.Entities;

namespace ProviderOptimizerService.Infrastructure.Persistence;

public class ProviderDbContext : DbContext
{
    public ProviderDbContext(DbContextOptions<ProviderDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProviderEntity> Providers => Set<ProviderEntity>();
}
