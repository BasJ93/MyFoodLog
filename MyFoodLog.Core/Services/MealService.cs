using AutoMapper;
using Microsoft.Extensions.Logging;
using MyFoodLog.Models;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;
using MyFoodLog.Models.Meals;

namespace MyFoodLog.Core.Services;

public class MealService : IMealService
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

    public async Task Create(CreateMealRequestDto requestDto, CancellationToken ctx = default)
    {
        Meal meal = new()
        {
            MealTypeId = requestDto.MealTypeId,
            Date = DateTime.Today
        };

        await _mealRepository.InsertAndSave(meal, ctx);
    }

    public async Task<IEnumerable<MealDto?>> GetMealsForDay(DateTime day, CancellationToken ctx = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MealDto?>> GetMealsForToday(CancellationToken ctx = default)
    {
        IEnumerable<Meal> meals = await _mealRepository.AllForToday(ctx);

        return _mapper.Map<IEnumerable<MealDto>>(meals);
    }

    public async Task CalculateValues(CancellationToken ctx = default)
    {
        throw new NotImplementedException();
    }
}