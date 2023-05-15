using MyFoodLog.Models;
using MyFoodLog.Models.FoodConsumption;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IFoodConsumptionService
{
    /// <summary>
    /// Add the consumption of a specified food to the specified type of meal.
    /// It will always be added to today's meal of that type.
    /// If no meal type was specified, it will be added based on the optional time specification of the types.
    /// </summary>
    /// <param name="requestDto">The request dto.</param>
    /// <param name="ctx">Cancellation token.</param>
    Task AddConsumption(AddConsumptionRequestDto requestDto, CancellationToken ctx);
    
    Task UpdateConsumption(CancellationToken ctx);

    /// <summary>
    /// Remove a <see cref="MyFoodLog.Database.Models.FoodItemConsumption"/> from the database.
    /// </summary>
    /// <param name="id">The id of the entry to delete.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A bool indicating success.</returns>
    Task<bool> DeleteConsumption(Guid id, CancellationToken ctx);
}