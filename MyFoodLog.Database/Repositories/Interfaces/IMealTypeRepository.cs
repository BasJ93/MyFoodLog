using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Repositories.Interfaces;

public interface IMealTypeRepository : IGenericCrudRepository<MealType>
{
    /// <summary>
    /// Get a <see cref="MealType"/> where the time range encloses the current time.
    /// </summary>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The meal type if found, otherwise null.</returns>
    Task<MealType?> GetByTimeRange(CancellationToken ctx = default);

    Task<MealType?> ByName(string name, CancellationToken ctx = default);
}