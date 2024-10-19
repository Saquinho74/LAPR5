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
            builder.Property(b => b.OperationalTypeName).HasColumnName("OperationalTypeName");
            builder.Property(b => b.RequiredStaffEntry).HasColumnName("RequiredStaffEntry");
            builder.Property(b => b.EstimatedDuration).HasColumnName("EstimatedDuration");
            builder.Property<bool>("_active").HasColumnName("Active");
        }
        
    }
}