using DDDNetCore.Domain.OperationType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDNetCore.Infraestructure.OperationTypes
{
    internal class OperationTypesEntityTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.ToTable("OperationType", SchemaNames.DDDSample1);
            builder.HasKey(b => b.Id);

            builder.OwnsOne(b => b.OperationalTypeName, owned =>
                {
                    owned.Property(d => d.Value).HasColumnName("OperationalTypeName");

                }

            );
            builder.OwnsOne(b => b.RequiredStaffEntry, owned =>
                {
                    owned.Property(d => d.RequiredStaff).HasColumnName("RequiredStaff");
                    owned.Property(d => d.Speciality).HasColumnName("Speciality");

                }
            );
            
            builder.OwnsOne(b => b.EstimatedDuration, owned =>
            {
                owned.Property(d => d.DurationInMinutes).HasColumnName("EstimatedDuration");
            });            builder.Property<bool>("_active").HasColumnName("Active");
        }
        
    }
}