using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Models;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.Meals;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/v1/meal")]
public sealed class MealController : ControllerBase
{
    private readonly IMealService _mealService;

    private readonly IMealTypeService _mealTypeService;

    public MealController(IMealService mealService, IMealTypeService mealTypeService)
    {
        _mealService = mealService;
        _mealTypeService = mealTypeService;
    }

    /// <summary>
    /// Create a new meal entry in the database.
    /// </summary>
    /// <param name="requestDto">The request dto.</param>
    /// <param name="ctx">Cancellation token.</param>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateMealRequestDto requestDto, CancellationToken ctx)
    {
        await _mealService.Create(requestDto, ctx);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> Delete(Guid id, CancellationToken ctx)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get the meal types the system knows about.
    /// </summary>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A list of known <see cref="MyFoodLog.Database.Models.MealType"/>s.</returns>
    [HttpGet("types")]
    [ProducesResponseType(typeof(IEnumerable<MealTypeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMealTypes(CancellationToken ctx)
    {
        return new JsonResult(await _mealTypeService.GetAll(ctx));
    }

    /// <summary>
    /// Get the meals for today, containing their respective food consumptions.
    /// </summary>
    /// <param name="ctx">Cancellation token</param>
    [HttpGet("meals")]
    [ProducesResponseType(typeof(IEnumerable<MealDto?>), StatusCodes.Status200OK)]
    [ProducesResponseType((StatusCodes.Status404NotFound))]
    public async Task<IActionResult> GetMeals(CancellationToken ctx)
    {
        return new JsonResult(await _mealService.GetMealsForToday(ctx));
    }
}