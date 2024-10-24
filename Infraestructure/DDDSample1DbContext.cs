using DDDNetCore.Domain.Categories;
using DDDNetCore.Domain.Credential;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.OperationType;
using DDDNetCore.Domain.Products;
using DDDNetCore.Infraestructure.Categories;
using DDDNetCore.Infraestructure.Credential;
using DDDNetCore.Infraestructure.Families;
using DDDNetCore.Infraestructure.Operation;
using DDDNetCore.Infraestructure.OperationTypes;
using DDDNetCore.Infraestructure.Patient;
using DDDNetCore.Infraestructure.Products;
using DDDNetCore.Infraestructure.Staff;
using DDDNetCore.Infraestructure.SurgeryRoom;
using Microsoft.EntityFrameworkCore;

namespace DDDNetCore.Infraestructure
{
    public class DddSample1DbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<DDDSample1.Domain.Patients.Patient> Patients { get; set; }

        public DbSet<Domain.Operation.Operation> Operation { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Family> Families { get; set; }
        
        public DbSet<OperationType> OperationTypes { get; set; }
        
        public DbSet<Domain.Credential.Credential> Credentials { get; set; }
        
        public DbSet<Domain.SurgeryRoom.SurgeryRoom> SurgeryRooms { get; set; }
        
        public DbSet<Domain.Staffs.Staff> Staff { get; set; }
        
        public DddSample1DbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OperationTypesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CredentialEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OperationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new SurgeryRoomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StaffEntityTypeConfiguration());
        }
    }
}