using DDDNetCore.Domain.Families;
using DDDNetCore.Infraestructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDNetCore.Infraestructure.Patient;

public class PatientRepository : BaseRepository<DDDSample1.Domain.Patients.Patient, PatientId>, IPatientRepository
{
    public PatientRepository(DddSample1DbContext context):base(context.Patients)
    {
    }
}