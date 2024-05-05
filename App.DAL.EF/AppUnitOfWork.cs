using App.Contracts.DAL;
using App.Contracts.DAL.Repositories;
using App.DAL.EF.Repositories;
using App.Domain.Identity;
using Base.Contracts.DAL;
using Base.DAL.EF;

namespace App.DAL.EF;

public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
{
    public AppUnitOfWork(AppDbContext uowDbContext) : base(uowDbContext)
    {
    }

    private ISectorRepository? _sectors;
    public ISectorRepository Sectors => _sectors ?? new SectorRepository(UowDbContext);
    
    private IUserInSectorRepository? _userInSectors;
    public IUserInSectorRepository UserInSectors => _userInSectors ?? new UserInSectorRepository(UowDbContext);

    private IEntityRepository<AppUser>? _users;
    public IEntityRepository<AppUser> Users => _users ??
                                               new BaseEntityRepository
                                                   <AppUser, AppUser, AppDbContext>(UowDbContext,
                                                       new DalDummyMapper<AppUser, AppUser>());
}