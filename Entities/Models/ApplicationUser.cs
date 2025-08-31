using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
}