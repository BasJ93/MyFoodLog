using Microsoft.Extensions.DependencyInjection;
using MyFoodLog.Database.Repositories;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.DependencyInjection;

public static class DatabaseHelper
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<MyFoodLogDbContext>();

        services.AddScoped<IFoodItemConsumptionRepository, FoodItemConsumptionRepository>();
        services.AddScoped<IFoodItemRepository, FoodItemRepository>();
        services.AddScoped<IMealRepository, MealRepository>();
        
        return services;
    }
}