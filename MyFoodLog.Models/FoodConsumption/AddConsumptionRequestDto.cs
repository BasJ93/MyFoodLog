using System.ComponentModel.DataAnnotations;

namespace MyFoodLog.Models.FoodConsumption;

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
    /// The Id for the meal type to add this item to.
    /// </summary>
    public Guid? MealTypeId { get; set; }
}