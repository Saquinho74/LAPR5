using DDDNetCore.Infraestructure;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Domain.Patient;

public class PatientRepository : BaseRepository<DDDSample1.Domain.Patients.Patient, PatientId>, IPatientRepository
{
    public PatientRepository(DddSample1DbContext context):base(context.Patients)
    {
    }
}