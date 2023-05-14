using Microsoft.EntityFrameworkCore;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.Repositories;

public class MealRepository : GenericCrudRepository<Meal>, IMealRepository
{
    public MealRepository(MyFoodLogDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Meal?> TodayByMealType(Guid mealTypeId, CancellationToken ctx = default)
    {
        return await ByDateAndMealType(DateTime.Today, mealTypeId, ctx);
    }

    /// <inheritdoc />
    public async Task<Meal?> ByDateAndMealType(DateTime date, Guid mealTypeId, CancellationToken ctx = default)
    {
        return await Table.FirstOrDefaultAsync(m => m.Date.Date == date.Date && m.MealTypeId == mealTypeId, ctx);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Meal>> AllByDate(DateTime date, CancellationToken ctx = default)
    {
        return await Table.AsNoTracking().Where(m => m.Date.Date == date.Date)
            .Include(m => m.MealType)
            .Include(m => m.ConsumedItems)
            .ThenInclude(c => c.FoodItem)
            .ToListAsync(ctx);
    }
}