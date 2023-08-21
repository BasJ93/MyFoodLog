using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFoodLog.Database.Repositories;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.DependencyInjection;

public static class DatabaseHelper
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        switch (configuration["DatabaseProvider"])
        {
            default:
                services.AddDbContext<MyFoodLogDbContext>(options =>
                    options.UseSqlite(configuration["ConnectionStrings:SQLite"]));
                break;
        }

        services.AddScoped<IFoodItemConsumptionRepository, FoodItemConsumptionRepository>();
        services.AddScoped<IFoodItemRepository, FoodItemRepository>();
        services.AddScoped<IMealRepository, MealRepository>();
        services.AddScoped<IMealTypeRepository, MealTypeRepository>();

        return services;
    }
}