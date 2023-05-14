using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/v1/day")]
public sealed class DayController : ControllerBase
{
    private readonly IMealService _mealService;

    public DayController(IMealService mealService)
    {
        _mealService = mealService;
    }

    /// <summary>
    /// Get the macronutrient values consumed on the specified date.
    /// </summary>
    /// <param name="date">The date to look for. If no date is provided, today is assumed.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The macro values.</returns>
    [Route("macros")]
    [ProducesResponseType(typeof(MacrosDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> MacrosForDay([FromQuery] DateTime date, CancellationToken ctx)
    {
        if (date == DateTime.MinValue)
        {
            date = DateTime.Now;
        }

        MacrosDto dto = await _mealService.CalculateValues(date, ctx);

        return new JsonResult(dto);
    }
}