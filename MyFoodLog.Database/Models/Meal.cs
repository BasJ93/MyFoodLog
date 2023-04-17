namespace MyFoodLog.Database.Models;

/// <summary>
/// Database model representing a meal.
/// </summary>
public class Meal : BaseId
{
    /// <summary>
    /// The date (and time) this meal was consumed (or created). The time is in UTC. 
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Foreign key for the type of meal.
    /// </summary>
    public Guid MealTypeId { get; set; }

    /// <summary>
    /// The type of the meal.
    /// </summary>
    public virtual MealType? MealType { get; set; }

    /// <summary>
    /// The navigational property containing the collection of <see cref="FoodItemConsumption"/> that make up this meal.
    /// </summary>
    public virtual ICollection<FoodItemConsumption> ConsumedItems { get; set; } = new HashSet<FoodItemConsumption>();
}