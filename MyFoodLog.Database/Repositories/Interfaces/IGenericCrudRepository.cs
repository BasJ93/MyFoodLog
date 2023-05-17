using Microsoft.EntityFrameworkCore;

namespace MyFoodLog.Database.Repositories.Interfaces;

public interface IGenericCrudRepository<T> where T : class
{
    /// <summary>
    /// Get all entities.
    /// </summary>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>An enumerable of the entities.</returns>
    Task<IEnumerable<T>> All(CancellationToken ctx = default);

    /// <summary>
    /// Get all entities.
    /// </summary>
    /// <param name="queryTrackingBehavior"></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>An enumerable of the entities.</returns>
    Task<IEnumerable<T>> All(QueryTrackingBehavior queryTrackingBehavior = QueryTrackingBehavior.TrackAll, CancellationToken ctx= default);

    /// <summary>
    /// Get an entity by it's id.
    /// </summary>
    /// <param name="id">Id of the entity.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The entity, or default if not found.</returns>
    Task<T?> ById(int id, CancellationToken ctx = default);

    /// <summary>
    /// Get an entity by it's id.
    /// </summary>
    /// <param name="id">Id of the entity.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The entity, or default if not found.</returns>
    Task<T?> ById(Guid id, CancellationToken ctx = default);
    
    /// <summary>
    /// Delete an entity by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task Delete(int id, CancellationToken ctx = default);
    
    /// <summary>
    /// Delete an entity by guid id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task Delete(Guid id, CancellationToken ctx = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task Delete(T entity, CancellationToken ctx = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task<int> DeleteAndSave(int id, CancellationToken ctx = default);
    
    /// <summary>
    /// Delete an entity and save the changes.
    /// </summary>
    /// <param name="id">The guid id.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task<int> DeleteAndSave(Guid id, CancellationToken ctx = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task<int> DeleteAndSave(T entity, CancellationToken ctx = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task Insert(T entity, CancellationToken ctx = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns></returns>
    Task<int> InsertAndSave(T entity, CancellationToken ctx = default);

    /// <summary>
    /// Save any outstanding tracked changes to the database.
    /// </summary>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The number of modified entities.</returns>
    Task<int> Save(CancellationToken ctx = default);
    
    /// <summary>
    /// Update an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    Task Update(T entity, CancellationToken ctx = default);

    /// <summary>
    /// Update an entity and save it to database.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    Task<int> UpdateAndSave(T entity, CancellationToken ctx = default);
}