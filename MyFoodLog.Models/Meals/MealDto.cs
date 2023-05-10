using MyFoodLog.Models.FoodConsumption;

namespace MyFoodLog.Models.Meals;

public class MealDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public IEnumerable<FoodConsumptionDto>? ConsumedFood { get; set; }
    
    public decimal Energy { get; set; }

    public decimal Fat { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Protein { get; set; }
}