using System.ComponentModel.DataAnnotations;

namespace MyFoodLog.Core.Models;

// TODO: Replace the name by the id? How are times from Grocy handled? 
public class AddConsumptionRequestDto
{
    /// <summary>
    /// The name of the item to add to this meal.
    /// </summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// The amount of this item consumed.
    /// </summary>
    [Required]
    public decimal Amount { get; set; }
    
    /// <summary>
    /// The Id for the meal to add this item to.
    /// </summary>
    public Guid MealId { get; set; }
}