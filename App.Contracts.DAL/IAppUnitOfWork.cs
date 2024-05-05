using App.Contracts.DAL.Repositories;
using App.Domain.Identity;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface IAppUnitOfWork : IUnitOfWork
{
    // list ur repos here
    ISectorRepository Sectors { get; }
    IUserInSectorRepository UserInSectors { get;  }
    IEntityRepository<AppUser> Users { get; }
}