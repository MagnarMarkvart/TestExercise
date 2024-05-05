using Base.Contracts.Domain;

namespace Base.Contracts.DAL;

public interface IEntityRepository<TEntity> : IEntityRepository<TEntity, Guid>
    where TEntity : class, IDomainEntityId
 {
    
}

public interface IEntityRepository<TEntity, in TKey>
    where TEntity : class, IDomainEntityId<TKey>
    where TKey : IEquatable<TKey>
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    int Remove(TEntity entity, TKey? userId = default);
    int Remove(TKey entityId, TKey? userId = default);
    
    TEntity FirstOrDefault(TKey entityId, TKey? userId = default, bool noTracking = true);
    IEnumerable<TEntity> GetAll(TKey? userId = default, bool noTracking = true);
    bool Exists(TKey entityId, TKey? userId = default);
    
    Task<TEntity> FirstOrDefaultAsync(TKey entityId, TKey? userId = default, bool noTracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true);
    Task<bool> ExistsAsync(TKey entityId, TKey? userId = default);
    Task<int> RemoveAsync(TEntity entity, TKey? userId = default);
    Task<int> RemoveAsync(TKey entityId, TKey? userId = default);
}