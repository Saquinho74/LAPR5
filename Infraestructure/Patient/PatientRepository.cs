using DDDNetCore.Domain.Categories;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Patient
{
    public class OperationRepository : BaseRepository<DDDSample1.Domain.Patients.Patient, PatientId>, IPatientRepository
    {
    
        public OperationRepository(DddSample1DbContext context):base(context.Patients)
        {
           
        }


    }
}