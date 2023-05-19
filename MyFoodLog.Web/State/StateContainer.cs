using MyFoodLog.Web.API.Client.Interfaces;

namespace MyFoodLog.Web.State;

public class StateContainer
{
    /// <summary>
    /// The item of food the user selected to add to a meal. Must be reset after every use!
    /// </summary>
    public FoodItemDto? SelectedFoodItem { get; set; }

    /// <summary>
    /// The previous url the user was on in our app.
    /// </summary>
    public string PreviousPage { get; set; } = String.Empty;

    /// <summary>
    /// The name of the meal to add a new item to. Must be reset after every use!
    /// </summary>
    public string MealName { get; set; } = String.Empty;
}