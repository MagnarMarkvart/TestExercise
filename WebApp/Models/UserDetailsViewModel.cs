using App.Domain;

namespace WebApp.Models;

public class UserDetailsViewModel
{
    public string? Name { get; set; }

    public IEnumerable<UserInSector> SelectedSectors { get; set; } = default!;

    public bool AgreesToTerms { get; set; }
}