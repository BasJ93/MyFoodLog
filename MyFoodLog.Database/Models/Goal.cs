namespace MyFoodLog.Database.Models;

/// <summary>
/// Database model for the goals of the user.
/// </summary>
public class Goal : BaseId
{
    /// <summary>
    /// Energy goal in kcal.
    /// </summary>
    public decimal Energy { get; set; }

    /// <summary>
    /// Fat goal in grams.
    /// </summary>
    public decimal? Fat { get; set; }

    /// <summary>
    /// Carbs goal in grams.
    /// </summary>
    public decimal? Carbohydrates { get; set; }
    
    /// <summary>
    /// Protein goal in grams.
    /// </summary>
    public decimal? Protein { get; set; }
}