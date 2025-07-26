using MyFoodLog.Core.Services;
using MyFoodLog.Models;
using MyFoodLog.Models.CalorieCalculator;

namespace MyFoodLog.Core.Tests;

public class CalorieCalculatorTests
{
    [Fact]
    public void Validate_BasalMetabolicRate()
    {
        BasalMetabolicRateInputDto input = new()
        {
            Age = 32,
            Height = 193,
            Weight = 140,
            Gender = Gender.Male,
        };

        CalorieCalculator uut = new();

        decimal stableCalories = uut.CalculateBasalMetabolicRate(input);
        
        Assert.Equal(2451.25M, stableCalories);
    }
    
    [Fact]
    public void Validate_BasalMetabolicRate_TDEE_Light()
    {
        BasalMetabolicRateInputDto input = new()
        {
            Age = 32,
            Height = 193,
            Weight = 140,
            Gender = Gender.Male,
        };

        CalorieCalculator uut = new();

        decimal stableCalories = uut.CalculateBasalMetabolicRate(input);
        
        Assert.Equal(2451.25M, stableCalories);
        
        int tdee = uut.CalculateTotalDailyEnergyExpenditure(stableCalories, ActivityLevel.SlightlyActive);
        
        Assert.Equal(3370, tdee);
    }
}