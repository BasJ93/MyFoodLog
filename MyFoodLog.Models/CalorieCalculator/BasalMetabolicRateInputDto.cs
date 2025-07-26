namespace MyFoodLog.Models.CalorieCalculator;

/// <summary>
/// Input DTO for the Basal Metabolic Rate calculation
/// </summary>
public class BasalMetabolicRateInputDto
{
    /// <summary>
    /// The age of the person in question, in years.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// The weight of the person in question, in kg.
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// The height of the person in question, in cm.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// The gender of the person in question, as the formula changes with gender.
    /// </summary>
    public Gender Gender { get; set; } = Gender.Male;
}