using DDDNetCore.DTO;
using DDDSample1.Domain.Patients;

namespace DDDNetCore.Mappers;

public interface IPatientMapper : IMapper<Patient,PatientMapper,PatientDTO > {
    
}