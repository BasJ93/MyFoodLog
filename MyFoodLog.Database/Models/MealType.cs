namespace MyFoodLog.Database.Models;

/// <summary>
/// Database model for a type of <see cref="Meal"/>.
/// </summary>
public sealed class MealType : BaseIdAndName
{
    /// <summary>
    /// The common start time of the <see cref="Meal"/>.
    /// </summary>
    public DateTimeOffset? StartTime { get; set; }
    
    /// <summary>
    /// The common end time of the <see cref="Meal"/>.
    /// </summary>
    public DateTimeOffset? EndTime { get; set; }   
}