using MyFoodLog.Models;
using MyFoodLog.Models.Meals;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IMealService
{
    Task Create(CreateMealRequestDto requestDto, CancellationToken ctx = default);

    Task<IEnumerable<MealDto?>> GetMealsForDay(DateTime day, CancellationToken ctx = default);
    
    Task<IEnumerable<MealDto?>> GetMealsForToday(CancellationToken ctx = default);

    /// <summary>
    /// Calculate the macro values for a given date.
    /// </summary>
    /// <param name="date">The date to calculate the macros for.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A dto containing the combined Carbs, Fat and Protein values for all the food eaten on the specified date.</returns>
    public Task<MacrosDto> CalculateValues(DateTime date, CancellationToken ctx = default);
}