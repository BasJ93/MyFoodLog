using MyFoodLog.Database.Models;
using MyFoodLog.Models.FoodConsumption;
using MyFoodLog.Models.FoodItem;

namespace MyFoodLog.Core.Services.Interfaces;

/// <summary>
/// Service to handle interaction with the <see cref="FoodItem"/> table.
/// </summary>
public interface IFoodItemService
{
    /// <summary>
    /// Get all <see cref="FoodItem"/>s from the database.
    /// </summary>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The collection of food items.</returns>
    Task<ICollection<FoodItemDto>> All(CancellationToken ctx = default);

    /// <summary>
    /// Get a <see cref="FoodItem"/> by id.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The food item, or null if not found.</returns>
    Task<FoodItemDto?> ById(Guid id, CancellationToken ctx = default);
    
    /// <summary>
    /// Create a new entry for a <see cref="FoodItem"/>.
    /// </summary>
    /// <param name="dto">The dto for the <see cref="FoodItem"/> to create.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The created food item.</returns>
    Task<FoodItemDto> Create(CreateFoodItemDto dto, CancellationToken ctx = default);

    /// <summary>
    /// Delete a <see cref="FoodItem"/> by id.
    /// </summary>
    /// <param name="id">The id of the food item to delete.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A boolean indicating success.</returns>
    Task<bool> Delete(Guid id, CancellationToken ctx = default);
    
    /// <summary>
    /// Search for <see cref="FoodItem"/>s by name of barcode.
    /// </summary>
    /// <param name="searchDto">The search request.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A collection of matching <see cref="FoodItemDto"/>s.</returns>
    Task<ICollection<FoodItemDto>> Search(SearchFoodDto searchDto, CancellationToken ctx = default);

    /// <summary>
    /// Update a <see cref="FoodItem"/>.
    /// </summary>
    /// <param name="id">The id of the food item to update.</param>
    /// <param name="updateDto">The new values to set it to.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The updated food item.</returns>
    Task<FoodItemDto> Update(Guid id, CreateFoodItemDto updateDto, CancellationToken ctx = default);
}