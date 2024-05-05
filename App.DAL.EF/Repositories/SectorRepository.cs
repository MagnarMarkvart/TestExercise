using App.Contracts.DAL.Repositories;
using App.Domain;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class SectorRepository : BaseEntityRepository<Sector, Sector, AppDbContext>, ISectorRepository
{
    public SectorRepository(AppDbContext dbContext) : 
        base(dbContext, new DalDummyMapper<Sector, Sector>())
    {
    }
    
    public override async Task<IEnumerable<Sector>> GetAllAsync(Guid userId = default, bool noTracking = true)
    {
        return (await CreateQuery(userId, noTracking)
                .Include("SuperSector")
                .ToListAsync())
            .Select(de => Mapper.MapLeftRight(de)).AsEnumerable()!;
    }

    public async Task<IEnumerable<Sector>> GetUserSectorsAsync(ICollection<UserInSector> userInSectors)
    {
        var sectorIds = userInSectors.Select(u => u.SectorId).ToList();

        var sectors = (await CreateQuery()
                .Where(s => sectorIds.Contains(s.Id))
                .Include("SuperSector")
                .ToListAsync())
            .Select(s => Mapper.MapLeftRight(s))
            .AsEnumerable();
            
        
        return sectors!;
    }

    public override async Task<Sector> FirstOrDefaultAsync(Guid entityId, Guid userId = default, bool noTracking = true)
    {
        return Mapper.MapLeftRight(await CreateQuery(userId, noTracking)
            .Include("SuperSector")
            .FirstOrDefaultAsync(m => m.Id.Equals(entityId)))!;
    }
}