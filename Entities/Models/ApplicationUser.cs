using Microsoft.AspNetCore.Identity;

namespace Entities.Models;

public class ApplicationUser : IdentityUser
{
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? EncryptedPassword { get; set; }
}