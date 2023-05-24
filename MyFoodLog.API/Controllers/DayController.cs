using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models;
using MyFoodLog.Models.Meals;

namespace MyFoodLog.API.Controllers;

/// <summary>
/// Controller to interact with data about a day.
/// </summary>
[ApiController]
[Route("/api/{version:apiVersion}/day/{date:datetime}")]
[ApiVersion("1.0")]
public sealed class DayController : ControllerBase
{
    private readonly IMealService _mealService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public DayController(IMealService mealService)
    {
        _mealService = mealService;
    }

    /// <summary>
    /// Get the macronutrient values consumed on the specified date.
    /// </summary>
    /// <param name="date">The date to look for.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The macro values.</returns>
    [Route("macros")]
    [ProducesResponseType(typeof(MacrosDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> MacrosForDay(DateTime date, CancellationToken ctx)
    {
        if (date == DateTime.MinValue)
        {
            date = DateTime.Now;
        }

        MacrosDto dto = await _mealService.CalculateValues(date, ctx);

        return new JsonResult(dto);
    }

    /// <summary>
    /// Get the meals for a given date, containing their respective food consumptions.
    /// </summary>
    /// <param name="date">The date to get the meals for.</param>
    /// <param name="ctx">Cancellation token</param>
    [HttpGet("meals")]
    [ProducesResponseType(typeof(IEnumerable<MealDto?>), StatusCodes.Status200OK)]
    [ProducesResponseType((StatusCodes.Status404NotFound))]
    public async Task<IActionResult> GetMeals(DateTime date, CancellationToken ctx)
    {
        return new JsonResult(await _mealService.GetMealsForDay(date, ctx));
    }
}