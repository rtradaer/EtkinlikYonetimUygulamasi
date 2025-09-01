using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

public class EtkinlikConfig : IEntityTypeConfiguration<Etkinlik>
{
    public void Configure(EntityTypeBuilder<Etkinlik> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasData(
            EtkinlikSeedData.GetEtkinlikler()
        );
    }
}