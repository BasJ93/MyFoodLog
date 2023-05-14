using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/v1/mealtype")]
public sealed class MealTypeController : ControllerBase
{
    private readonly IMealTypeService _mealTypeService;

    public MealTypeController(IMealTypeService mealTypeService)
    {
        _mealTypeService = mealTypeService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateMealTypeDto requestDto, CancellationToken ctx)
    {
        await _mealTypeService.Create(requestDto, ctx);

        return Ok();
    }
}