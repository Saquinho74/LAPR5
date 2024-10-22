using DDDNetCore.Domain.OperationType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DDDNetCore.Infraestructure.OperationTypes
{
    internal class OperationTypesEntityTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.HasKey(b => b.Id);

            builder.OwnsOne(b => b.OperationTypeName, nameBuilder =>
            {
                nameBuilder.Property(p => p.Value)
                    .HasColumnName("Name");
            });

            builder.OwnsOne(b => b.RequiredStaffEntry, staffBuilder =>
            {
                staffBuilder.Property(p => p.Value)
                    .HasColumnName("Speciality");
            });

            builder.OwnsOne(b => b.EstimatedDuration, durationBuilder =>
            {
                durationBuilder.Property(p => p.Value)
                    .HasColumnName("EstimatedDuration");
            });
        }

    }
}