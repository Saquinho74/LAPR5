using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDNetCore.Infraestructure.Staff;

public class StaffEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Staff.Staff>
{
    public void Configure(EntityTypeBuilder<Domain.Staff.Staff> builder)
    {
        builder.ToTable("Staff", SchemaNames.DDDSample1);
        builder.HasKey(b => b.Id);

        builder.OwnsOne(b => b.Specialization,
            nameBuilder => { nameBuilder.Property(p => p.Value).HasColumnName("Specialization"); });

        builder.OwnsOne(s => s.LicenseNumber, ln =>
        {
            ln.Property(l => l.Value).HasColumnName("LicenseNumber"); // Ensure proper mapping
        });

        builder.HasMany(b => b.Slot)
            .WithOne()
            .HasForeignKey("Id")
            .IsRequired();
    }
}