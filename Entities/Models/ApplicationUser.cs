using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public DateTime? BirthDate { get; set; }
}