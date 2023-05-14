using AutoMapper;
using Microsoft.Extensions.Logging;
using MyFoodLog.Models;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;
using MyFoodLog.Models.Meals;

namespace MyFoodLog.Core.Services;

public sealed class MealService : IMealService
{
    private readonly ILogger<MealService> _logger;
    private readonly IMealRepository _mealRepository;
    private readonly IMapper _mapper;

    public MealService(IMealRepository mealRepository, ILogger<MealService> logger, IMapper mapper)
    {
        _mealRepository = mealRepository;
        _logger = logger;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task Create(CreateMealRequestDto requestDto, CancellationToken ctx = default)
    {
        Meal meal = new()
        {
            MealTypeId = requestDto.MealTypeId,
            Date = DateTime.Today
        };

        await _mealRepository.InsertAndSave(meal, ctx);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MealDto?>> GetMealsForDay(DateTime day, CancellationToken ctx = default)
    {
        IEnumerable<Meal> meals = await _mealRepository.AllByDate(day, ctx);

        return _mapper.Map<IEnumerable<MealDto>>(meals);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MealDto?>> GetMealsForToday(CancellationToken ctx = default)
    {
        return await GetMealsForDay(DateTime.Today, ctx);
    }

    /// <inheritdoc />
    public async Task<MacrosDto> CalculateValues(DateTime date, CancellationToken ctx = default)
    {
        List<MealDto?> meals = (await GetMealsForDay(date, ctx)).ToList();

        foreach (MealDto? meal in meals)
        {
            if (meal != null)
            {
                meal.Carbohydrates = meal.ConsumedFood.Sum(c => c.Carbohydrates);
                meal.Fat = meal.ConsumedFood.Sum(c => c.Fat);
                meal.Protein = meal.ConsumedFood.Sum(c => c.Protein);
            }
        }

        MacrosDto dto = new()
        {
            Carbohydrates = meals.Sum(m => m.Carbohydrates),
            Fat = meals.Sum(m => m.Fat),
            Protein = meals.Sum(m => m.Protein)
        };
        
        return dto;
    }
}