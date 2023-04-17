using Microsoft.Extensions.DependencyInjection;
using MyFoodLog.ClientApis.Interfaces;

namespace MyFoodLog.ClientApis.DependencyInjection;

public static class OpenFoodFactsHelper
{
    public static IServiceCollection AddOpenFoodFacts(this IServiceCollection services)
    {
        services.AddScoped<IOpenFoodFactsClient, OpenFoodFactsClient>();
        
        return services;
    }
}