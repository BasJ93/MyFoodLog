using Microsoft.EntityFrameworkCore;
using MyFoodLog.Database.Models;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.Repositories;

public class FoodItemRepository: GenericCrudRepository<FoodItem>, IFoodItemRepository
{
    public FoodItemRepository(MyFoodLogDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<FoodItem?> ByName(string name, CancellationToken ctx = default)
    {
        return await Table.FirstOrDefaultAsync(i => i.Name == name, ctx);
    }

    /// <inheritdoc />
    public async Task<ICollection<FoodItem>> SearchByName(string name, CancellationToken ctx = default)
    {
        // TODO: Add missing % signs to name for the pattern
        return await Table.Where(f => !string.IsNullOrEmpty(f.Name) && EF.Functions.Like(f.Name, $"%{name}%")).ToListAsync(ctx);
    }

    /// <inheritdoc />
    public async Task<FoodItem?> ByEAN13(long code, CancellationToken ctx = default)
    {
        return await Table.FirstOrDefaultAsync(i => i.EAN13 == code, ctx);
    }
}