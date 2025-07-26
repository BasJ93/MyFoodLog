namespace MyFoodLog.Models.CalorieCalculator;

public enum ActivityLevel
{
    /// <summary>
    /// Desk job, with little or no exercise
    /// </summary>
    Sedentary,
    
    /// <summary>
    /// Exercise 1-3 times per week
    /// </summary>
    SlightlyActive,
    
    /// <summary>
    /// Exercise 3-5 times per week
    /// </summary>
    ModeratelyActive,
    
    /// <summary>
    /// Exercise 6-7 times per week
    /// </summary>
    VeryActive,
    
    /// <summary>
    /// Physical job or regular training
    /// </summary>
    ExtremelyActive,
}