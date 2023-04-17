using Microsoft.Extensions.Logging;
using MyFoodLog.Core.Models;
using MyFoodLog.Core.Models.FoodConsumption;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Core.Services;

public class FoodConsumptionService : IFoodConsumptionService
{

    private readonly ILogger<FoodConsumptionService> _logger;
    
    private readonly IFoodItemConsumptionRepository _foodItemConsumption;

    
    // TODO: replace with the service?
    private readonly IFoodItemRepository _foodItems;

    public FoodConsumptionService(IFoodItemConsumptionRepository foodItemConsumption, ILogger<FoodConsumptionService> logger, IFoodItemRepository foodItems)
    {
        _foodItemConsumption = foodItemConsumption;
        _logger = logger;
        _foodItems = foodItems;
    }

    // TODO: Add a response model to tell the controller what it's response should be. Maybe borrow the one from Carlo (Elephant on nuget)
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

        FoodItemConsumption consumption = new FoodItemConsumption
        {
            FoodItem = food,
            Amount = requestDto.Amount,
            MealId = requestDto.MealId
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
    
    static bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
}