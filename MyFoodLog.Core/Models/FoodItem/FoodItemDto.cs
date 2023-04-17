namespace MyFoodLog.Core.Models.FoodItem;

public class FoodItemDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string? QuantityUnit { get; set; }
    
    public decimal Energy { get; set; }

    public decimal Fat { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Protein { get; set; }
}