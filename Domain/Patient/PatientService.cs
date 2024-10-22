using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DDDNetCore.Domain.Patient;

public class PatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPatientRepository _patientRepository;
    private readonly ILogger<PatientService> logger;
    private readonly IConfiguration _configuration;
    private PatientMapper _patientMapper;

    public PatientService(IUnitOfWork unitOfWork, IPatientRepository patientRepository, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _patientRepository = patientRepository;
        _configuration = configuration;
        _patientMapper = new PatientMapper();
    }

    public async Task<object> RegisterPatient(PatientDTO dto)
    {
        try
        {
            dto.PatientID = Guid.NewGuid().ToString();

            DDDSample1.Domain.Patients.Patient mapped = _patientMapper.ToEntity(dto);

            await this._patientRepository.AddAsync(mapped);

            PatientDTO mappedDto = _patientMapper.ToDTO(mapped);

            await this._unitOfWork.CommitAsync();

            return mappedDto;
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            throw new Exception("Error registering patient");
        }
    }

    public Task<List<PatientDTO>> GetPatients()
    {
        throw new NotImplementedException();
    }
}