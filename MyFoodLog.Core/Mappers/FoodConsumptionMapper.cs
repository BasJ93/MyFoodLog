using MyFoodLog.Database.Models;
using MyFoodLog.Models.FoodConsumption;

namespace MyFoodLog.Core.Mappers;

public static class FoodConsumptionMapper
{
    public static FoodConsumptionDto ToDto(FoodItemConsumption foodItemConsumption)
    {
        return new()
        {
            Id = foodItemConsumption.Id,
            Amount = foodItemConsumption.Amount,
            Carbohydrates = foodItemConsumption.FoodItem?.Carbohydrates ?? Decimal.Zero,
            Energy = foodItemConsumption.FoodItem?.Energy ?? Decimal.Zero,
            Fat = foodItemConsumption.FoodItem?.Fat ?? Decimal.Zero,
            Protein = foodItemConsumption.FoodItem?.Protein ?? Decimal.Zero,
            QuantityUnit = foodItemConsumption.FoodItem?.QuantityUnit ?? string.Empty,
            Name = foodItemConsumption.FoodItem?.Name ?? string.Empty,
        };
    }
}