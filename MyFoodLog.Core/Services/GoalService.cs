using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;
using MyFoodLog.Models.Goals;

namespace MyFoodLog.Core.Services;

/// <inheritdoc />
public class GoalService : IGoalService
{
    private readonly IGoalRepository _goalRepository;
    
    public GoalService(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<Guid?> CreateGoal(CreateGoalDto goalDto, CancellationToken ctx)
    {
        Goal goal = new()
        {
            Energy = goalDto.Energy,
            Carbohydrates = goalDto.Carbohydrates,
            Fat = goalDto.Fat,
            Protein = goalDto.Protein,
        };

        Goal createdGoal = await _goalRepository.SetGoal(goal, ctx);
        
        return createdGoal.Id;
    }

    /// <inheritdoc />
    public async Task<decimal?> GetEnergyGoal(CancellationToken ctx = default)
    {
        Goal? goal = await _goalRepository.GetGoal(ctx);

        if (goal == null)
        {
            return null;
        }

        return goal.Energy;
    }

    /// <inheritdoc />
    public async Task<MacrosGoalDto?> GetMacrosGoal(CancellationToken ctx = default)
    {
        Goal? goal = await _goalRepository.GetGoal(ctx);

        if (goal == null)
        {
            return null;
        }

        // TODO: Consider making the dto properties nullable.
        
        return new()
        {
            Carbohydrates = goal.Carbohydrates ?? 0.0m,
            Fat = goal.Fat ?? 0.0m,
            Protein = goal.Protein ?? 0.0m,
        };
    }

    public async Task<(bool update, Guid id)> UpdateGoal(Guid id, CreateGoalDto goalDto, CancellationToken ctx = default)
    {
        Goal? goal = await _goalRepository.GetGoal(ctx);

        if (goal == null)
        {
            Guid? newId = await CreateGoal(goalDto, ctx);
            return (false, newId ?? Guid.Empty);
        }
        else
        {
            goal.Energy = goalDto.Energy;
            goal.Carbohydrates = goalDto.Carbohydrates;
            goal.Fat = goalDto.Fat;
            goal.Protein = goalDto.Protein;
            
            await _goalRepository.SetGoal(goal, ctx);
            
            return (true, goal.Id);
        }
    }
}