using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Repositories.Interfaces;

public interface IFoodItemRepository : IGenericCrudRepository<FoodItem>
{
    /// <summary>
    /// Find a <see cref="FoodItem"/> by name.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The food item, or null if it does not exist.</returns>
    Task<FoodItem?> ByName(string name, CancellationToken ctx = default);

    /// <summary>
    /// Search for <see cref="FoodItem"/>s by name.
    /// </summary>
    /// <param name="name">The name to search for.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A collection of food items, if found.</returns>
    Task<ICollection<FoodItem>> SearchByName(string name, CancellationToken ctx = default);

    /// <summary>
    /// Find a <see cref="FoodItem"/> by it's barcode (EAN13).
    /// </summary>
    /// <param name="code">The EAN13 format barcode.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The food item, or null if it does not exist.</returns>
    Task<FoodItem?> ByEAN13(long code, CancellationToken ctx = default);
}