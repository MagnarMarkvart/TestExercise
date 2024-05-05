using Base.Contracts.Domain;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Identity;

public class AppUser : IdentityUser<Guid>, IDomainEntityId
{
    public ICollection<UserInSector>? UserInSectors { get; set; }
    public ICollection<AppRefreshToken>? RefreshTokens { get; set; }
    public bool AgreesToTerms { get; set; } = default!;
    public string Name { get; set; } = default!;
}