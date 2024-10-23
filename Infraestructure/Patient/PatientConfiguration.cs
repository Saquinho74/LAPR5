using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDNetCore.Infraestructure.Patient
{
    internal class PatientConfiguration : IEntityTypeConfiguration<DDDSample1.Domain.Patients.Patient>
    {
        public void Configure(EntityTypeBuilder<DDDSample1.Domain.Patients.Patient> builder)
        {
            // Configure the table name
            builder.ToTable("Patient", SchemaNames.DDDSample1);

            // Configure the primary key
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.AllergiesMedicalConditions);
            // Configure the properties
            

            builder.OwnsOne(b => b.DateOfBirth, nameBuilder =>
            {
                nameBuilder.Property(p => p.DateOfBirthValue).HasColumnName("DateOfBirth");
            });

            builder.Property(b => b.Gender)
                .HasColumnName("Gender");

            builder.OwnsOne(b => b.MedicalRecordNumber, nameBuilder =>
            {
                nameBuilder.Property(p => p.medicalRecordNumber)
                    .HasColumnName("MedicalRecordNumber");
            });

            builder.OwnsOne(b => b.ContactInformation, nameBuilder =>
            {
                nameBuilder.Property(p => p.contactInformation)
                    .HasColumnName("ContactInformation");
            });

            builder.OwnsOne(b => b.EmergencyContact, nameBuilder =>
            {
                nameBuilder.Property(p => p.emergyContact)
                    .HasColumnName("EmergencyContact");
            });

            builder.OwnsOne(b => b.AppointmentHistory, nameBuilder =>
            {
                nameBuilder.Property(p => p.appointementHistory)
                    .HasColumnName("AppointmentHistory");
            });

            
        }
    }
}