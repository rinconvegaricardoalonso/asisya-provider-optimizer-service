using Microsoft.Extensions.DependencyInjection;
using ProviderOptimizerService.Application.UseCases;

namespace ProviderOptimizerService.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register use cases
        services.AddScoped<OptimizeProviderUseCase>();

        return services;
    }
}
