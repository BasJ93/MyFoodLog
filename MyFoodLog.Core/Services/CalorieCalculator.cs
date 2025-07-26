using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models;
using MyFoodLog.Models.CalorieCalculator;

namespace MyFoodLog.Core.Services;

/// <inheritdoc />
public class CalorieCalculator : ICalorieCalculator
{
    /// <inheritdoc />
    public decimal CalculateBasalMetabolicRate(BasalMetabolicRateInputDto input)
    {
        // Mifflin-St Jeor Equation
        decimal bmr = (10M * input.Weight) + (6.25M * input.Height) - (5M * input.Age);

        if (input.Gender == Gender.Male)
            bmr = bmr + 5;
        else
            bmr = bmr - 161;
        
        return bmr;
    }

    /// <inheritdoc />
    public int CalculateTotalDailyEnergyExpenditure(decimal bmr, ActivityLevel activityLevel)
    {
        // I can't find any propper source for the values below, but they do seem to be the common used values.
        decimal tdee = 0M;
        
        switch (activityLevel)
        {
            case ActivityLevel.Sedentary:
                tdee = bmr * 1.2M;
                break;
            case ActivityLevel.SlightlyActive:
                tdee = bmr * 1.375M;
                break;
            case ActivityLevel.ModeratelyActive:
                tdee = bmr * 1.55M;
                break;
            case ActivityLevel.VeryActive:
                tdee = bmr * 1.725M;
                break;
            case ActivityLevel.ExtremelyActive:
                tdee = bmr * 1.9M;
                break;
            default:
                throw new NotImplementedException();
        }
        
        return Convert.ToInt32(Math.Round(tdee));
    }
}