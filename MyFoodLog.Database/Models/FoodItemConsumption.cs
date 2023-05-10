namespace MyFoodLog.Database.Models;

/// <summary>
/// Database model representing the consumption of a <see cref="FoodItem"/> in a <see cref="Meal"/>.
/// </summary>
public class FoodItemConsumption : BaseId
{
    /// <summary>
    /// The Id for the <see cref="Meal"/> that this consumption is part of.
    /// </summary>
    public Guid MealId { get; set; }
    
    //TODO: Is this a required key? If so, how do we handle stuff coming from Grocy?
    /// <summary>
    /// The Id for the <see cref="FoodItem"/> that is consumed.
    /// </summary>
    public Guid FoodItemId { get; set; }
    
    /// <summary>
    /// The amount of the <see cref="FoodItem"/> that is consumed.
    /// </summary>
    public decimal Amount { get; set; }
    
    // TODO: If Grocy items are not copied to the database, do we need the energy and macro fields?
    
    /// <summary>
    /// Navigational property for <see cref="Meal"/>.
    /// </summary>
    public virtual Meal? Meal { get; set; }
    
    /// <summary>
    /// Navigational property for <see cref="FoodItem"/>.
    /// </summary>
    public virtual FoodItem? FoodItem { get; set; }
}