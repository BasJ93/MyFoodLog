using MyFoodLog.Web.API.Client.Interfaces;

namespace MyFoodLog.Web.State;

public class StateContainer
{
    /// <summary>
    /// The item of food the user selected to add to a meal.
    /// </summary>
    public FoodItemDto? SelectedFoodItem { get; set; }
}