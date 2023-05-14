using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Repositories.Interfaces;

public interface IMealRepository : IGenericCrudRepository<Meal>
{
    /// <summary>
    /// Get the meal for the given type for today.
    /// </summary>
    /// <param name="mealTypeId">The id of the <see cref="MealType"/>.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The meal, or null if it was not found.</returns>
    Task<Meal?> TodayByMealType(Guid mealTypeId, CancellationToken ctx = default);

    /// <summary>
    /// Get the meal for the given type for the given day.
    /// </summary>
    /// <param name="date">The day to search for the meal.</param>
    /// <param name="mealTypeId">The id of the <see cref="MealType"/>.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The meal, or null if it was not found.</returns>
    Task<Meal?> ByDateAndMealType(DateTime date, Guid mealTypeId, CancellationToken ctx = default);

    /// <summary>
    /// Get all meals for a given date.
    /// </summary>
    /// <param name="date">The date to search for.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A collection of meals. Empty if none are found for that date.</returns>
    Task<IEnumerable<Meal>> AllByDate(DateTime date, CancellationToken ctx = default);
}