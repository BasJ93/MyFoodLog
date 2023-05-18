using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Models;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.Meals;

namespace MyFoodLog.API.Controllers;

/// <summary>
/// Controller to interact with <see cref="MyFoodLog.Database.Models.Meal"/>s.
/// </summary>
[ApiController]
[Route("/api/v1/meals")]
public sealed class MealController : ControllerBase
{
    private readonly IMealService _mealService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public MealController(IMealService mealService)
    {
        _mealService = mealService;
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
    /// Get the meals for today, containing their respective food consumptions.
    /// </summary>
    /// <param name="ctx">Cancellation token</param>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<MealDto?>), StatusCodes.Status200OK)]
    [ProducesResponseType((StatusCodes.Status404NotFound))]
    public async Task<IActionResult> GetMeals(CancellationToken ctx)
    {
        return new JsonResult(await _mealService.GetMealsForToday(ctx));
    }
}