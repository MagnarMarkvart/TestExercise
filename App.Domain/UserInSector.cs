using App.Domain.Identity;
using Base.Contracts.Domain;
using Base.Domain;

namespace App.Domain;

public class UserInSector : BaseEntityId, IDomainAppUser<AppUser> {
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    
    public Guid SectorId { get; set; }
    public Sector? Sector { get; set; }
}