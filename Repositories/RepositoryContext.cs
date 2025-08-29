using System.Reflection;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Etkinlik> Etkinlikler { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // EF Core Repository.Config dosyasını otomatik buluyor

    }
}
