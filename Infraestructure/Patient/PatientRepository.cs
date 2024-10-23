using DDDNetCore.Domain.Categories;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.Patient;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Patient
{
    public class PatientRepository : BaseRepository<DDDSample1.Domain.Patients.Patient, PatientId>
    {
        public PatientRepository(DddSample1DbContext context) : base(context.Patients)
        {
        }
    }
}