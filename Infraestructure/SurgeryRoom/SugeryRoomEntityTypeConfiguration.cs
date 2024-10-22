using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDNetCore.Domain.SurgeryRoom; // Ensure the correct namespace for SurgeryRoom

namespace DDDNetCore.Infraestructure.SurgeryRoom
{
    internal class SurgeryRoomEntityTypeConfiguration : IEntityTypeConfiguration<Domain.SurgeryRoom.SurgeryRoom>
    {
        public void Configure(EntityTypeBuilder<Domain.SurgeryRoom.SurgeryRoom> builder)
        {
            // Map to the database table
            builder.ToTable("SurgeryRoom", SchemaNames.DDDSample1);

            // Define the primary key
            builder.HasKey(b => b.Id);

            // Map the AssignedEquipment property
            builder.OwnsOne(b => b.AssignedEquipment, owned =>
            {
                owned.Property(d => d.Value)
                     .HasColumnName("AssignedEquipment") // Map to the appropriate column name
                     .IsRequired(); // Specify if it's required
            });

            // Map the CurrentStatus property
            builder.Property(b => b.CurrentStatus)
                   .HasConversion<string>() // Convert enum to string
                   .HasColumnName("CurrentStatus") // Column name in the database
                   .IsRequired(); // Ensure it's required

            // Map the Capacity property
            builder.OwnsOne(b => b.Capacity, owned =>
            {
                owned.Property(d => d.Value)
                     .HasColumnName("Capacity") // Adjust to match your domain
                     .IsRequired(); // Specify if it's required
            });

            // Map the MaintenanceSlot property
            builder.OwnsOne(b => b.MaintenanceSlot, owned =>
            {
                owned.Property(d => d.Date)
                     .HasColumnName("MaintenanceDate") // Adjust column name as needed
                     .IsRequired();

                owned.Property(d => d.StartTime)
                     .HasColumnName("MaintenanceStartTime") // Adjust as necessary
                     .IsRequired();

                owned.Property(d => d.EndTime)
                     .HasColumnName("MaintenanceEndTime") // Adjust as necessary
                     .IsRequired();
            });

            // Map the Type property
            builder.OwnsOne(b => b.Type, owned =>
            {
                owned.Property(d => d.Value)
                     .HasColumnName("Type") // Adjust to match your domain
                     .IsRequired(); // Specify if it's required
            });
        }
    }
}
