using MyFoodLog.Database.Models;

namespace MyFoodLog.Database.Repositories.Interfaces;

public interface IGoalRepository : IGenericCrudRepository<Goal>
{
    /// <summary>
    /// Get the goal for the user. Can return null if no goal is configured.
    /// </summary>
    /// <returns></returns>
    Task<Goal?> GetGoal(CancellationToken ctx = default);
    
    /// <summary>
    /// Set the goal for the user.
    /// </summary>
    /// <param name="goal"></param>
    /// <returns></returns>
    Task<Goal> SetGoal(Goal goal, CancellationToken ctx = default);
}