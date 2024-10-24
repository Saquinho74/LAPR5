﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDNetCore.Infraestructure.Staff;

public class StaffEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Staffs.Staff>
{
    public void Configure(EntityTypeBuilder<Domain.Staffs.Staff> builder)
    {
        builder.ToTable("Staff", SchemaNames.DDDSample1);
        builder.HasKey(b => b.Id);

        builder.OwnsOne(b => b.Specialization,
            nameBuilder => { nameBuilder.Property(p => p.Value).HasColumnName("Specialization"); });

        builder.OwnsOne(s => s.LicenseNumber, ln =>
        {
            ln.Property(l => l.Value).HasColumnName("LicenseNumber"); // Ensure proper mapping
        });

        builder.OwnsMany(b => b.Slot, slot =>
        {
            slot.ToTable("AvailabilitySlots"); // Specify table for the value object if needed
            slot.Property(s => s.slot) // Maps the "slot" property of AvailabilitySlot
                .HasColumnName("Slot");
        });
        
    }
}