using System;
using DDDNetCore.Domain.Families;
using DDDNetCore.DTO;
using DDDSample1.Domain.Patients;

namespace DDDNetCore.Mappers;

public class PatientMapper
{
    public Patient ToEntity(PatientDTO dto)
    {
        return new Patient(dto.patientID, dto.DateOfBirth, dto.Gender, dto.MedicalRecordNumber,
            dto.ContactInformation, dto.EmergencyContact, dto.AppointmentHistory, dto.AllergiesMedicalConditions);
    }

    public PatientDTO ToDTO(Patient entity)
    {
        return new PatientDTO(entity.PatientID, entity.DateOfBirth, entity.Gender, entity.MedicalRecordNumber,
            entity.ContactInformation, entity.EmergencyContact, entity.AppointmentHistory,
            entity.AllergiesMedicalConditions);
    }

    public Patient toEntity(PatientDTO createDto)
    {
        throw new NotImplementedException();
    }
}