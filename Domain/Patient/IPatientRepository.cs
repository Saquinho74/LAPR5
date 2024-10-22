using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Patient;

public interface IPatientRepository : IRepository<DDDSample1.Domain.Patients.Patient, PatientId>
{
}