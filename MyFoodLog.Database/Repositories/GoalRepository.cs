using Microsoft.EntityFrameworkCore;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.Repositories;

public class GoalRepository : GenericCrudRepository<Goal>, IGoalRepository
{
    public GoalRepository(MyFoodLogDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Goal?> GetGoal(CancellationToken ctx = default)
    {
        return await Table.FirstOrDefaultAsync(ctx);
    }

    public async Task<Goal> SetGoal(Goal goal, CancellationToken ctx = default)
    {
        Goal? existing = await Table.FirstOrDefaultAsync(ctx);

        if (existing == null)
        {
            await InsertAndSave(goal, ctx);
            return goal;
        }
        
        existing.Energy = goal.Energy;
        existing.Carbohydrates = goal.Carbohydrates;
        existing.Protein = goal.Protein;
        existing.Fat = goal.Fat;
        
        await UpdateAndSave(existing, ctx);
        
        return existing;
    }
}