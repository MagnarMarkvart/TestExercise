namespace App.Domain;

public class SectorGroup
{
    public Guid SectorId { get; set; }
    public string Name { get; set; } = default!;
    public List<SectorGroup> Subgroups { get; set; } = [];
    public List<Sector> SelectableSectors { get; set; } = [];
}