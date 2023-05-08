using Microsoft.Extensions.Logging;
using MyFoodLog.Models;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Core.Services;

public class MealService : IMealService
{
    private readonly ILogger<MealService> _logger;
    private readonly IMealRepository _mealRepository;

    public MealService(IMealRepository mealRepository, ILogger<MealService> logger)
    {
        _mealRepository = mealRepository;
        _logger = logger;
    }

    public async Task Create(CreateMealRequestDto requestDto, CancellationToken ctx = default)
    {
        Meal meal = new()
        {
            MealTypeId = requestDto.MealTypeId,
            Date = DateTime.UtcNow
        };

        await _mealRepository.InsertAndSave(meal, ctx);
    }

    public async Task CalculateValues(CancellationToken ctx = default)
    {
        throw new NotImplementedException();
    }
}