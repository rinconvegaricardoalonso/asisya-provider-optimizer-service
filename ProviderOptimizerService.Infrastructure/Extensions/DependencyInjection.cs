using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProviderOptimizerService.Application.Interfaces;
using ProviderOptimizerService.Infrastructure.Persistence;
using ProviderOptimizerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace ProviderOptimizerService.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddDbContext<ProviderDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IProviderRepository, ProviderRepository>();

        return services;
    }
}
