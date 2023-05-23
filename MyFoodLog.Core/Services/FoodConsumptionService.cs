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

    // TODO: replace with the service?
    private readonly IFoodItemRepository _foodItems;
    
    private readonly IMealRepository _meals;
    
    private readonly IMealTypeRepository _mealTypes;

    public FoodConsumptionService(IFoodItemConsumptionRepository foodItemConsumption, ILogger<FoodConsumptionService> logger, IFoodItemRepository foodItems, IMealRepository meals, IMealTypeRepository mealTypes)
    {
        _foodItemConsumption = foodItemConsumption;
        _logger = logger;
        _foodItems = foodItems;
        _meals = meals;
        _mealTypes = mealTypes;
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
            meal = await _meals.TodayByMealType(requestDto.MealTypeId.Value, ctx) ?? new()
            {
                Date = DateTime.Today,
                MealTypeId = requestDto.MealTypeId.Value
            };
        }
        else
        {
            // No meal type was provided. See if we can find one that fits the time range
            MealType? mealType = await _mealTypes.GetByTimeRange(ctx);

            if (mealType != null)
            {
                // Let's see if we already have a meal for that type.
                meal = await _meals.TodayByMealType(mealType.Id, ctx) ?? new()
                {
                    Date = DateTime.Today,
                    MealTypeId = mealType.Id
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

    /// <inheritdoc />
    public async Task<bool> UpdateConsumption(Guid id, decimal amount, CancellationToken ctx)
    {
        FoodItemConsumption? consumption = await _foodItemConsumption.ById(id, ctx);

        if (consumption != null)
        {
            consumption.Amount = amount;

            int changes = await _foodItemConsumption.UpdateAndSave(consumption, ctx);
            
            return changes > 0;
        }

        return false;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteConsumption(Guid id, CancellationToken ctx)
    {
        _logger.LogInformation("Attempting to remove food consumption entry {id}", id);

        int changes = await _foodItemConsumption.DeleteAndSave(id, ctx);

        return changes > 0;
    }
}