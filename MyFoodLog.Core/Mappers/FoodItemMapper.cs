using MyFoodLog.Database.Models;
using MyFoodLog.Models.FoodItem;

namespace MyFoodLog.Core.Mappers;

public static class FoodItemMapper
{
    public static FoodItemDto ToDto(this FoodItem foodItem)
    {
        return new ()
        {
            Id = foodItem.Id,
            Name = foodItem.Name ?? string.Empty,
            QuantityUnit = foodItem.QuantityUnit,
            Carbohydrates = foodItem.Carbohydrates,
            Energy = foodItem.Energy,
            Fat = foodItem.Fat,
            Protein = foodItem.Protein,
        };
    }

    public static FoodItem ToModel(this CreateFoodItemDto dto)
    {
        return new()
        {
            Name = dto.Name,
            QuantityUnit = dto.QuantityUnit,
            Carbohydrates = dto.Carbohydrates,
            Energy = dto.Energy,
            Fat = dto.Fat,
            Protein = dto.Protein,
        };
    }
}