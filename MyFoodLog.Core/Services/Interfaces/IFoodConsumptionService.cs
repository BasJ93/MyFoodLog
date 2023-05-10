using MyFoodLog.Models;
using MyFoodLog.Models.FoodConsumption;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IFoodConsumptionService
{
    /// <summary>
    /// Add the consumption of a specified food to the specified type of meal.
    /// It will always be added to today's meal of that type.
    /// </summary>
    /// <param name="requestDto">The request dto.</param>
    /// <param name="ctx">Cancellation token.</param>
    Task AddConsumption(AddConsumptionRequestDto requestDto, CancellationToken ctx);
    
    Task UpdateConsumption(CancellationToken ctx);

    Task DeleteConsumption(CancellationToken ctx);
}