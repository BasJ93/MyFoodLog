using MyFoodLog.Database.Models;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.Core.Mappers;

public static class MealTypeMapper
{
    public static MealTypeDto ToDto(this MealType mealType)
    {
        return new()
        {
            Id = mealType.Id,
            Name = mealType.Name ?? string.Empty,
        };
    }
}