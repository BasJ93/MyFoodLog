using Microsoft.EntityFrameworkCore;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.Repositories;

public class MealTypeRepository : GenericCrudRepository<MealType>, IMealTypeRepository
{
    public MealTypeRepository(MyFoodLogDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<MealType?> GetByTimeRange(CancellationToken ctx = default)
    {
        return await Table
            .Where(m => m.StartTime != null && m.EndTime != null)
            .Where(m =>
                m.StartTime.Value.TimeOfDay <= DateTime.Now.TimeOfDay &&
                m.EndTime.Value.TimeOfDay >= DateTime.Now.TimeOfDay)
            .FirstOrDefaultAsync(ctx);
    }

    public async Task<MealType?> ByName(string name, CancellationToken ctx = default)
    {
        return await Table.Where(m => m.Name == name).FirstOrDefaultAsync(ctx);
    }
}