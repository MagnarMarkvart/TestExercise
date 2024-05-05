using App.Contracts.DAL.Repositories;
using App.Domain.Identity;
using Base.Contracts.DAL;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class UserRepository : BaseEntityRepository<AppUser, AppUser, AppDbContext>, IUserRepository
{
    public UserRepository(AppDbContext dbContext, IDalMapper<AppUser, AppUser> mapper) : base(dbContext, mapper)
    {
    }
    
    public override async Task<AppUser> FirstOrDefaultAsync(Guid entityId, Guid userId = default, bool noTracking = true)
    {
        return Mapper.MapLeftRight(await CreateQuery(userId, noTracking)
            .Include("UserInSectors")
            .FirstOrDefaultAsync(m => m.Id.Equals(entityId)))!;
    }
}