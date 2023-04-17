namespace MyFoodLog.Database.Models;

/// <summary>
/// Database base model for an item with an id.
/// </summary>
public class BaseId
{
    /// <summary>
    /// The id of the item.
    /// </summary>
    public Guid Id { get; set; }
}