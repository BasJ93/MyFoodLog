using MyFoodLog.Models;
using MyFoodLog.Models.Meals;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IMealService
{
    Task Create(CreateMealRequestDto requestDto, CancellationToken ctx = default);

    Task<IEnumerable<MealDto?>> GetMealsForDay(DateTime day, CancellationToken ctx = default);
    
    Task<IEnumerable<MealDto?>> GetMealsForToday(CancellationToken ctx = default);

    Task CalculateValues(CancellationToken ctx = default);
}