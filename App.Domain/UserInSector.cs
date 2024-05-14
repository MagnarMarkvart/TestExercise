using System.ComponentModel.DataAnnotations.Schema;
using App.Domain.Identity;
using Base.Contracts.Domain;

namespace App.Domain;

public class UserInSector : BaseEntityId, IDomainAppUser<AppUser>
{
    public string? SectorWithSuperSectorsName { get; set; }
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    
    public Guid SectorId { get; set; }
    public Sector? Sector { get; set; }
}