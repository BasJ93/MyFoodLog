using MyFoodLog.Models.FoodItem;

namespace MyFoodLog.Models.FoodConsumption;

public class FoodConsumptionDto : FoodItemDto
{
    public Guid Id { get; set; }
    
    public decimal Amount { get; set; }
}