using App.Contracts.DAL.Repositories;
using App.Domain;
using Base.Contracts.DAL;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class UserInSectorRepository : BaseEntityRepository<UserInSector, UserInSector, AppDbContext>, IUserInSectorRepository
{
    public UserInSectorRepository(AppDbContext dbContext) : 
        base(dbContext, new DalDummyMapper<UserInSector, UserInSector>())
    {
    }
    
    public override async Task<IEnumerable<UserInSector>> GetAllAsync(Guid userId = default, bool noTracking = true)
    {
        return (await CreateQuery(userId, noTracking)
                .Include("Sector")
                .Include("AppUser")
                .ToListAsync())
            .Select(de => Mapper.MapLeftRight(de)).AsEnumerable()!;
    }
    
    public override async Task<UserInSector> FirstOrDefaultAsync(Guid entityId, Guid userId = default, bool noTracking = true)
    {
        return Mapper.MapLeftRight(await CreateQuery(userId, noTracking)
            .Include("AppUser")
            .Include("Sector")
            .FirstOrDefaultAsync(m => m.Id.Equals(entityId)))!;
    }
}