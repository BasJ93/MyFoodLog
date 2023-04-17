using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Models;
using MyFoodLog.Core.Services.Interfaces;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/v1/meal")]
public class MealController : ControllerBase
{
    private readonly IMealService _mealService;

    public MealController(IMealService mealService)
    {
        _mealService = mealService;
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
}