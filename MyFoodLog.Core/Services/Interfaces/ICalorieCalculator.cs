using MyFoodLog.Models.CalorieCalculator;

namespace MyFoodLog.Core.Services.Interfaces;

public interface ICalorieCalculator
{
    /// <summary>
    /// Calculate the Basal Metabolic Rate for a person.
    /// </summary>
    decimal CalculateBasalMetabolicRate(BasalMetabolicRateInputDto input);

    /// <summary>
    /// Calculate the Total Daily Energy Expenditure for a person, based on their BMR and activity level.
    /// </summary>
    int CalculateTotalDailyEnergyExpenditure(decimal bmr, ActivityLevel activityLevel);
}