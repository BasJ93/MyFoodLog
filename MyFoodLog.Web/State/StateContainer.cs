using MyFoodLog.Models.FoodItem;

namespace MyFoodLog.Web.State;

public class StateContainer
{
    /// <summary>
    /// The item of food the user selected to add to a meal.
    /// </summary>
    public FoodItemDto? SelectedFoodItem { get; set; }
}