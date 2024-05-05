using Base.Contracts.DAL;
using Base.Contracts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Base.DAL.EF;

public class BaseEntityRepository<TDomainEntity, TDalEntity, TDbContext> 
    : BaseEntityRepository<Guid, TDomainEntity, TDalEntity, TDbContext>, IEntityRepository<TDalEntity>
    where TDomainEntity : class, IDomainEntityId
    where TDalEntity : class, IDomainEntityId
    where TDbContext : DbContext
{
    public BaseEntityRepository(TDbContext dbContext, IDalMapper<TDomainEntity, TDalEntity> mapper) : base(dbContext, mapper)
    {
    }
}

public class BaseEntityRepository<TKey, TDomainEntity, TDalEntity, TDbContext>
    where TKey : IEquatable<TKey>
    where TDomainEntity : class, IDomainEntityId
    where TDalEntity : class, IDomainEntityId
    where TDbContext : DbContext
{
    protected readonly TDbContext RepoDbContext;
    protected readonly DbSet<TDomainEntity> RepoDbSet;
    protected readonly IDalMapper<TDomainEntity, TDalEntity> Mapper;
    
    public BaseEntityRepository(TDbContext dbContext, IDalMapper<TDomainEntity, TDalEntity> mapper)
    {
        RepoDbContext = dbContext;
        RepoDbSet = RepoDbContext.Set<TDomainEntity>();
        Mapper = mapper;
    }

    protected virtual IQueryable<TDomainEntity> CreateQuery(TKey? userId = default, bool noTracking = true)
    {
        var query = RepoDbSet.AsQueryable();
        if (userId != null && !userId.Equals(default) &&
            typeof(IDomainAppUserId<TKey>).IsAssignableFrom(typeof(TDomainEntity)))
        {
            query = query
                .Include("AppUser")
                .Where(e => ((IDomainAppUserId<TKey>) e).AppUserId.Equals(userId));
        }

        if (noTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }
    
    public virtual TDalEntity Add(TDalEntity entity)
    {
        return Mapper.MapLeftRight(RepoDbSet.Add(Mapper.MapRightLeft(entity)!).Entity)!;
    }

    public virtual TDalEntity Update(TDalEntity entity)
    {
        return Mapper.MapLeftRight(RepoDbSet.Update(Mapper.MapRightLeft(entity)!).Entity)!;
    }

    public virtual int Remove(TDalEntity entity, TKey? userId = default)
    {
        if (userId == null)
        {
            return RepoDbSet
                .Where(e => e.Id.Equals(entity.Id))
                .ExecuteDelete();
        }

        return CreateQuery(userId)
            .Where(e => e.Id.Equals(entity.Id))
            .ExecuteDelete();
    }

    public virtual int Remove(TKey entityId, TKey? userId = default)
    {
        if (userId == null)
        {
            return RepoDbSet
                .Where(e => e.Id.Equals(entityId))
                .ExecuteDelete();
        }

        return CreateQuery(userId)
            .Where(e => e.Id.Equals(entityId))
            .ExecuteDelete();
    }

    public virtual IEnumerable<TDalEntity> GetAll(TKey? userId = default, bool noTracking = true)
    {
        return CreateQuery(userId, noTracking).ToList().Select(de => Mapper.MapLeftRight(de)).AsEnumerable()!;
    }

    public virtual bool Exists(TKey entityId, TKey? userId = default)
    {
        return CreateQuery(userId).Any(e => e.Id.Equals(entityId));
    }

    public virtual async Task<IEnumerable<TDalEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true)
    {
        return (await CreateQuery(userId, noTracking)
                .ToListAsync())
                .Select(de => Mapper.MapLeftRight(de)).AsEnumerable()!;
    }

    public virtual async Task<bool> ExistsAsync(TKey entityId, TKey? userId = default)
    {
        return await CreateQuery(userId).AnyAsync(e => e.Id.Equals(entityId));
    }

    public virtual async Task<int> RemoveAsync(TDalEntity entity, TKey? userId = default)
    {
        if (userId == null)
        {
            return await RepoDbSet
                .Where(e => e.Id.Equals(entity.Id))
                .ExecuteDeleteAsync();
        }

        return await CreateQuery(userId)
            .Where(e => e.Id.Equals(entity.Id))
            .ExecuteDeleteAsync();
    }

    public virtual async Task<int> RemoveAsync(TKey entityId, TKey? userId = default)
    {
        if (userId == null)
        {
            return await RepoDbSet
                .Where(e => e.Id.Equals(entityId))
                .ExecuteDeleteAsync();
        }

        return await CreateQuery(userId)
            .Where(e => e.Id.Equals(entityId))
            .ExecuteDeleteAsync();
    }
    
    public virtual TDalEntity FirstOrDefault(TKey entityId, TKey? userId = default, bool noTracking = true)
    {
        return Mapper.MapLeftRight(CreateQuery(userId, noTracking).FirstOrDefault(m => m.Id.Equals(entityId)))!;
    }

    public virtual async Task<TDalEntity> FirstOrDefaultAsync(TKey entityId, TKey? userId = default, bool noTracking = true)
    {
        return Mapper.MapLeftRight(await CreateQuery(userId, noTracking).FirstOrDefaultAsync(m => m.Id.Equals(entityId)))!;
    }
}
