using MyFoodLog.Models.FoodItem;

namespace MyFoodLog.Models.FoodConsumption;

public class FoodConsumptionDto : FoodItemDto
{
    public decimal Amount { get; set; }
}