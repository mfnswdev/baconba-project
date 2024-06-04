using BaconBA.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaconBA.Data;

public class WeightEntityTypeConfiguration : IEntityTypeConfiguration<Weight>
{

    public void Configure(EntityTypeBuilder<Weight> builder)
    {
       builder.ToTable("Weights");
            builder.HasKey(w => w.Id);
            builder.Property(w => w.AnimalId).IsRequired();
            builder.Property(w => w.Date).IsRequired();
            builder.Property(w => w.WeightValue).IsRequired();
    }
}
