using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.Goals;

namespace MyFoodLog.API.Controllers;

/// <summary>
/// Controller to interact with <see cref="MyFoodLog.Database.Models.Goal"/>s.
/// </summary>
[ApiController]
[Route("/api/{version:apiVersion}/goals")]
[ApiVersion("1.0")]
public class GoalController : Controller
{
    private readonly IGoalService _goalService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GoalController(IGoalService goalService)
    {
        _goalService = goalService;
    }

    /// <summary>
    /// Get the energy goal for the user.
    /// </summary>
    [HttpGet("energy")]
    [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEnergy(CancellationToken ctx)
    {
        decimal? energyGoal = await _goalService.GetEnergyGoal(ctx);

        if (energyGoal is null)
        {
            return NotFound();
        }
        
        return Ok(energyGoal);
    }
    
    /// <summary>
    /// Get the macros goal for the user.
    /// </summary>
    [HttpGet("macros")]
    [ProducesResponseType(typeof(MacrosGoalDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMacros(CancellationToken ctx)
    {
        MacrosGoalDto? macrosGoalDto = await _goalService.GetMacrosGoal(ctx);

        if (macrosGoalDto is null)
        {
            return NotFound();
        }
        
        return Ok(macrosGoalDto);
    }

    /// <summary>
    /// Create a new goal for the user.
    /// </summary>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> SetGoal(CreateGoalDto goalDto, CancellationToken ctx)
    {
        (bool update, Guid id) = await _goalService.UpdateGoal(Guid.Empty, goalDto, ctx);

        if (update)
        {
            return Ok();
        }
        
        return Created($"{Request.Path.Value}/{id}", null);
    }
}