using Microsoft.EntityFrameworkCore;
using MyFoodLog.Database.Repositories.Interfaces;

namespace MyFoodLog.Database.Repositories;

public class GenericCrudRepository<T> : IGenericCrudRepository<T> where T : class
{
    private readonly MyFoodLogDbContext _db;
    protected readonly DbSet<T> Table;

    public GenericCrudRepository(MyFoodLogDbContext dbContext)
    {
        _db = dbContext;
        Table = dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> All(CancellationToken ctx = default)
    {
        return await Table.ToListAsync(ctx);
    }

    public async Task<IEnumerable<T>> All(QueryTrackingBehavior queryTrackingBehavior = QueryTrackingBehavior.TrackAll,
        CancellationToken ctx = default)
    {
        return await Table.AsTracking(queryTrackingBehavior).ToListAsync(ctx);
    }

    public async Task<T?> ById(int id, CancellationToken ctx = default)
    {
        return await Table.FindAsync(id, ctx);
    }

    public async Task Delete(int id, CancellationToken ctx = default)
    {
        T? existing = await Table.FindAsync(id, ctx);

        if (existing != null)
        {
            Table.Remove(existing);
        }
    }

    public async Task Delete(T entity, CancellationToken ctx = default)
    {
        Table.Remove(entity);
    }

    public async Task<int> DeleteAndSave(int id, CancellationToken ctx = default)
    {
        await Delete(id, ctx);

        return await _db.SaveChangesAsync(ctx);
    }

    public async Task<int> DeleteAndSave(T entity, CancellationToken ctx = default)
    {
        await Delete(entity, ctx);

        return await _db.SaveChangesAsync(ctx);
    }

    public async Task Insert(T entity, CancellationToken ctx = default)
    {
        await Table.AddAsync(entity, ctx);
    }

    public async Task<int> InsertAndSave(T entity, CancellationToken ctx = default)
    {
        await Insert(entity, ctx);

        return await _db.SaveChangesAsync(ctx);
    }

    public async Task<int> Save(CancellationToken ctx = default)
    {
        return await _db.SaveChangesAsync(ctx);
    }

    public async Task Update(T entity, CancellationToken ctx = default)
    {
        Table.Update(entity);
    }

    public async Task<int> UpdateAndSave(T entity, CancellationToken ctx = default)
    {
        await Update(entity, ctx);

        return await _db.SaveChangesAsync(ctx);
    }
}