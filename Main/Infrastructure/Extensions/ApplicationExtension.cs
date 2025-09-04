using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Main.Infrastructure.Extensions;

public static class ApplicationExtension
{
    public static void Configure_And_Check_Migration(this IApplicationBuilder app)
    {
        RepositoryContext context = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }

    public static async void Configure_DefaultAdminUser(this IApplicationBuilder app)
    {
        const string adminUser = "admin@admin.com";
        const string adminPassword = "Admin123@#$$";

        //UserManager
        UserManager<ApplicationUser> userManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<ApplicationUser>>();
        //RoleManager
        RoleManager<IdentityRole> roleManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        ApplicationUser user = await userManager.FindByEmailAsync(adminUser);
        if (user is null)
        {
            user = new ApplicationUser()
            {
                Email = "admin@admin.com",
                UserName = adminUser,
                EmailConfirmed = true,
                Id = "0000",
                FirstName = "Admin",
                LastName = "Admin"
            };

            var result = await userManager.CreateAsync(user, adminPassword);
            if (!result.Succeeded)
                throw new Exception("Admin kullanıcısı oluşturulamadı.");

            var roleResult = await userManager.AddToRolesAsync(user,
                roleManager
                    .Roles
                    .Select(role => role.Name)
                    .ToList()
            );

            if (!roleResult.Succeeded)
                throw new Exception("Admin için rol atamasında bir hata oluştu.");
        }
    }  
}