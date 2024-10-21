using DDDNetCore.Domain.Families;
using DDDNetCore.Infraestructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDNetCore.Infraestructure.Patient;

public class PatientRepository : BaseRepository<DDDSample1.Domain.Patients.Patient, PatientID>, IPatientRepository
{
    public PatientRepository(DbSet<DDDSample1.Domain.Patients.Patient> objs) : base(objs)
    {
    }
}