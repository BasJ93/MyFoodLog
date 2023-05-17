using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/{version:apiVersion}/mealtype")]
[ApiVersion("1.0")]
public sealed class MealTypeController : ControllerBase
{
    private readonly IMealTypeService _mealTypeService;

    public MealTypeController(IMealTypeService mealTypeService)
    {
        _mealTypeService = mealTypeService;
    }
    
    /// <summary>
    /// Create a new <see cref="MyFoodLog.Database.Models.MealType"/> that can be assigned to meals during the day.
    /// </summary>
    /// <param name="requestDto">The request model.</param>
    /// <param name="ctx">Cancellation token</param>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateMealTypeDto requestDto, CancellationToken ctx)
    {
        // TODO: Return the created object
        
        await _mealTypeService.Create(requestDto, ctx);

        return Ok();
    }
}