using System.ComponentModel.DataAnnotations;

namespace MyFoodLog.Models.FoodItem;

/// <summary>
/// DTO to create a new <see cref="FoodItem"/>.
/// </summary>
public class CreateFoodItemDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string? EAN13 { get; set; }
    
    public string? QuantityUnit { get; set; }
    
    public decimal Energy { get; set; }
    
    public decimal Fat { get; set; }
    
    public decimal Carbohydrates { get; set; }
    
    public decimal Protein { get; set; }
}