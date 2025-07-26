using MyFoodLog.Models.Goals;

namespace MyFoodLog.Core.Services.Interfaces;

public interface IGoalService
{
    /// <summary>
    /// Create the energy and macros goal for the user.
    /// </summary>
    /// <param name="goalDto"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    Task<Guid?> CreateGoal(CreateGoalDto goalDto, CancellationToken ctx);
    
    /// <summary>
    /// Get the energy goal (in kcal) for the user.
    /// </summary>
    /// <param name="ctx"><see cref="CancellationToken"/></param>
    /// <returns>The value, or null if no goal is defined.</returns>
    Task<decimal?> GetEnergyGoal(CancellationToken ctx = default);
    
    /// <summary>
    /// Get the optional macros goal for the user.
    /// </summary>
    /// <param name="ctx"><see cref="CancellationToken"/></param>
    /// <returns>A <see cref="MacrosGoalDto"/> containing one or more of those goals, or null if no goals are defined.</returns>
    Task<MacrosGoalDto?> GetMacrosGoal(CancellationToken ctx = default);
    
    /// <summary>
    /// Update the energy and macros goal for the user.
    /// </summary>
    /// <param name="goalDto"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    Task<(bool update, Guid id)> UpdateGoal(Guid id, CreateGoalDto goalDto, CancellationToken ctx = default);
}