using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Mappers;
namespace DDDNetCore.Domain.Patient;

public class PatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPatientRepository _patientRepository;
    

    public PatientService(IUnitOfWork unitOfWork, IPatientRepository patientRepository)
    {
        _unitOfWork = unitOfWork;
        _patientRepository = patientRepository;

    }


    public async Task<List<PatientDto>> GetAllAsync()
    {
        var patients = await _patientRepository.GetAllAsync();

        // Conversão das operações em DTOs
        var listDto = PatientMapper.toDTOList(patients);

        return listDto;
    }

    public async Task<PatientDto> GetByIdAsync(PatientId id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);

        if (patient == null)
            return null;

        var dtoReturn = PatientMapper.ToDTO(patient);

        return dtoReturn;
    }

    // Método para adicionar um novo patient
    public async Task<PatientDto> AddAsync(PatientDto dto)

    {
        var patient = new DDDSample1.Domain.Patients.Patient(
            new PatientId(dto.PatientId),
            new DateOfBirth(dto.DateOfBirth),
            (Gender)Enum.Parse(typeof(Gender), dto.Gender),
            new MedicalRecordNumber(dto.MedicalRecordNumber),
            new ContactInformation(dto.ContactInformation),
            new EmergencyContact(dto.EmergencyContact),
            new AppointmentHistory(dto.AppointmentHistory),
            new AllergiesMedicalConditions(dto.AllergiesMedicalConditions)
        );

        await _patientRepository.AddAsync(patient);
        await _unitOfWork.CommitAsync();

        var dtoReturn = PatientMapper.ToDTO(patient);

        return dtoReturn;
    }

    // Método para atualizar um patient existente
    public async Task<PatientDto> UpdateAsync(PatientDto dto)
    {
        var patient = await _patientRepository.GetByIdAsync(new PatientId(dto.PatientId));

        if (patient == null)
            return null;

        // Atualiza as informações do paciente
        patient.ChangeDateOfBirth(new DateOfBirth(dto.DateOfBirth));
        patient.ChangeGender((Gender)Enum.Parse(typeof(Gender), dto.Gender));
        patient.ChangeMedicalRecordNumber(new MedicalRecordNumber(dto.MedicalRecordNumber));
        patient.ChangeContactInformation(new ContactInformation(dto.ContactInformation));
        patient.ChangeEmergencyContact(new EmergencyContact(dto.EmergencyContact));
        patient.ChangeAppointmentHistory(new AppointmentHistory(dto.AppointmentHistory));
        patient.ChangeAllergiesMedicalConditions(new AllergiesMedicalConditions(dto.AllergiesMedicalConditions));

        await _unitOfWork.CommitAsync();

        var dtoReturn = PatientMapper.ToDTO(patient);

        return dtoReturn;
    }

    public async Task<PatientDto> InactivateAsync(PatientId id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);

        if (patient == null)
            return null;

        // Aqui você deve implementar a lógica para inativar a operação

        await _unitOfWork.CommitAsync();

        var dtoReturn = PatientMapper.ToDTO(patient);

        return dtoReturn;
    }

    public async Task<PatientDto> DeleteAsync(PatientId id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);

        if (patient == null)
            return null;

        _patientRepository.Remove(patient);
        await _unitOfWork.CommitAsync();

        var dtoReturn = PatientMapper.ToDTO(patient);

        return dtoReturn;
    }
}