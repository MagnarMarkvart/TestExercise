namespace App.Domain;

public class Sector : BaseEntityId
{
    public string Description { get; set; } = default!;
    
    public Guid? SuperSectorId { get; set; }
    public Sector? SuperSector { get; set; }
    
    public ICollection<UserInSector>? UserInSectors { get; set; }
    public ICollection<Sector>? Sectors { get; set; }
}