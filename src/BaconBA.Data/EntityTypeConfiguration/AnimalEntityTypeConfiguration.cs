using BaconBA.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaconBA.Data;

public class AnimalEntityTypeConfiguration : IEntityTypeConfiguration<AnimalEntity>
{
    public void Configure(EntityTypeBuilder<AnimalEntity> builder)
    {
        builder.ToTable("Animals");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Eartag).IsRequired().HasMaxLength(6);
        builder.Property(c => c.GenitorEartag).IsRequired().HasMaxLength(6);
        builder.Property(c => c.MatriarchEartag).IsRequired().HasMaxLength(6);
        builder.Property(c => c.BirthDate).IsRequired();
        builder.Property(c => c.CheckoutDate);
        builder.Property(c => c.Status).IsRequired();
        builder.Property(c => c.Gender).IsRequired();
        builder.HasIndex(c => c.Eartag).IsUnique();

          builder.HasMany(c => c.Weights)
                   .WithOne(w => w.Animal)
                   .HasForeignKey(w => w.AnimalId)
                   .OnDelete(DeleteBehavior.Cascade);
    }
}
