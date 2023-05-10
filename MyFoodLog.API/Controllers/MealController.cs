using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Models;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.Meals;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/v1/meal")]
public class MealController : ControllerBase
{
    private readonly IMealService _mealService;

    private readonly IMealTypeService _mealTypeService;

    public MealController(IMealService mealService, IMealTypeService mealTypeService)
    {
        _mealService = mealService;
        _mealTypeService = mealTypeService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateMealRequestDto requestDto, CancellationToken ctx)
    {
        await _mealService.Create(requestDto, ctx);

        return Ok();
    }

    [HttpPost("delete")]
    public Task<IActionResult> Delete(CancellationToken ctx)
    {
        throw new NotImplementedException();
    }

    [HttpGet("types")]
    [ProducesResponseType(typeof(IEnumerable<MealTypeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMealTypes(CancellationToken ctx)
    {
        return new JsonResult(await _mealTypeService.GetAll(ctx));
    }

    /// <summary>
    /// Get the meals for today, containing their respective food consumptions.
    /// </summary>
    /// <param name="ctx"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("meals")]
    [ProducesResponseType(typeof(IEnumerable<MealDto?>), StatusCodes.Status200OK)]
    [ProducesResponseType((StatusCodes.Status404NotFound))]
    public async Task<IActionResult> GetMeals(CancellationToken ctx)
    {
        return new JsonResult(await _mealService.GetMealsForToday(ctx));
    }
}