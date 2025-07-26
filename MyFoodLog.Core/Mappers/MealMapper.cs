using MyFoodLog.Database.Models;
using MyFoodLog.Models.Meals;

namespace MyFoodLog.Core.Mappers;

public static class MealMapper
{
    public static MealDto ToDto(this Meal meal)
    {
        return new()
        {
            Id = meal.Id,
            ConsumedFood = meal.ConsumedItems.Select(FoodConsumptionMapper.ToDto),
            Name = meal.MealType?.Name ?? string.Empty,
        };
    }
}