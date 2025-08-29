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
}