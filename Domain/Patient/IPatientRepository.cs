using System.Threading.Tasks;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Shared;
using DDDNetCore.DTO;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Patient;

public interface IPatientRepository : IRepository<DDDSample1.Domain.Patients.Patient, PatientId>
{
}