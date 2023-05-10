using Microsoft.Extensions.Logging;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;
using MyFoodLog.Models.FoodConsumption;

namespace MyFoodLog.Core.Services;

public class FoodConsumptionService : IFoodConsumptionService
{

    private readonly ILogger<FoodConsumptionService> _logger;
    
    private readonly IFoodItemConsumptionRepository _foodItemConsumption;

    private readonly IMealRepository _meals;

    
    // TODO: replace with the service?
    private readonly IFoodItemRepository _foodItems;

    public FoodConsumptionService(IFoodItemConsumptionRepository foodItemConsumption, ILogger<FoodConsumptionService> logger, IFoodItemRepository foodItems, IMealRepository meals)
    {
        _foodItemConsumption = foodItemConsumption;
        _logger = logger;
        _foodItems = foodItems;
        _meals = meals;
    }

    // TODO: Add a response model to tell the controller what it's response should be. Maybe borrow the one from Carlo (Elephant on nuget)
    /// <inheritdoc />
    public async Task AddConsumption(AddConsumptionRequestDto requestDto, CancellationToken ctx)
    {
        if (requestDto.Name == null)
        {
            _logger.LogWarning("Attempt to add food consumption with no food item name.");
            return;
        }
        
        FoodItem? food = await _foodItems.ByName(requestDto.Name, ctx);
        if (food == null)
        {
            _logger.LogWarning("Food item [{name}] does not exist in the database.", requestDto.Name);
            return;
        }

        Meal? meal = null;
        
        // Find the meal for the type and today, otherwise create a new meal for the type.
        if (requestDto.MealTypeId != null && requestDto.MealTypeId != Guid.Empty)
        {
            meal = await _meals.TodayByMealType(requestDto.MealTypeId.Value, ctx);
            
            if (meal == null)
            {
                meal = new Meal
                {
                    Date = DateTime.Today,
                    MealTypeId = requestDto.MealTypeId.Value
                };
            }
        }
        
        //TODO: Check if the food was already added to the meal. If so, do ???
        
        FoodItemConsumption consumption = new FoodItemConsumption
        {
            FoodItem = food,
            Amount = requestDto.Amount,
            Meal = meal
        };

        _logger.LogInformation("Added consumption of {amount} {food}", requestDto.Amount, requestDto.Name);
        await _foodItemConsumption.InsertAndSave(consumption, ctx);
    }

    public async Task UpdateConsumption(CancellationToken ctx)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteConsumption(CancellationToken ctx)
    {
        throw new NotImplementedException();
    }
}