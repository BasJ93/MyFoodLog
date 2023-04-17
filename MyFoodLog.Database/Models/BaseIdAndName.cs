namespace MyFoodLog.Database.Models;

/// <summary>
/// Base model for a database item with a name and id.
/// </summary>
public class BaseIdAndName : BaseId
{
    /// <summary>
    /// The name of the database item.
    /// </summary>
    public string? Name { get; set; }
}