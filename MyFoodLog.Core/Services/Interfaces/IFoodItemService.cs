using MyFoodLog.Core.Models.FoodConsumption;
using MyFoodLog.Core.Models.FoodItem;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Core.Services.Interfaces;

/// <summary>
/// Service to handle interaction with the <see cref="FoodItem"/> table.
/// </summary>
public interface IFoodItemService
{
    /// <summary>
    /// Create a new entry for a <see cref="FoodItem"/>.
    /// </summary>
    /// <param name="dto">The dto for the <see cref="FoodItem"/> to create.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task Create(CreateFoodItemDto dto, CancellationToken ctx);
    
    /// <summary>
    /// Search for <see cref="FoodItem"/>s by name of barcode.
    /// </summary>
    /// <param name="searchDto">The search request.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A collection of matching <see cref="FoodItemDto"/>s.</returns>
    Task<ICollection<FoodItemDto>> Search(SearchFoodDto searchDto, CancellationToken ctx);
}