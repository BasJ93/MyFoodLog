using Microsoft.Extensions.DependencyInjection;
using MyFoodLog.Core.Services;
using MyFoodLog.Core.Services.Interfaces;

namespace MyFoodLog.Core.DependencyInjection;

public static class CoreHelper
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IFoodConsumptionService, FoodConsumptionService>();
        services.AddScoped<IFoodItemService, FoodItemService>();
        services.AddScoped<IMealService, MealService>();
        
        return services;
    }
}