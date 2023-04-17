namespace MyFoodLog.Database.Models;

/// <summary>
/// Database model for an item of food.
/// </summary>
public class FoodItem : BaseIdAndName
{
    /// <summary>
    /// The barcode in European format.
    /// 13 digits long.
    /// </summary>
    public long? EAN13 { get; set; }
    
    /// <summary>
    /// The unit used to measure an amount of the food item. I.E. piece, gram, milliliter, ...
    /// </summary>
    public string? QuantityUnit { get; set; }
    
    /// <summary>
    /// The energy in kcal per <see cref="QuantityUnit"/>.
    /// </summary>
    public decimal Energy { get; set; }
    
    /// <summary>
    /// The fat in grams per <see cref="QuantityUnit"/>.
    /// </summary>
    public decimal Fat { get; set; }
    
    /// <summary>
    /// The carbs in grams per <see cref="QuantityUnit"/>.
    /// </summary>
    public decimal Carbohydrates { get; set; }
    
    /// <summary>
    /// The protein in grams per <see cref="QuantityUnit"/>.
    /// </summary>
    public decimal Protein { get; set; }
}