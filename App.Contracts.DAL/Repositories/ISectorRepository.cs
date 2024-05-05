using App.Domain;
using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface ISectorRepository : IEntityRepository<Sector>
{
    // define your custom methods here
    Task<IEnumerable<Sector>> GetUserSectorsAsync(ICollection<UserInSector> userInSectors);
}