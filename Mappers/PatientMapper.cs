using System;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Patient;
using DDDSample1.Domain.Patients;

namespace DDDNetCore.Mappers;

public class PatientMapper
{
    public Patient ToEntity(PatientDTO dto)
    {
        return new Patient(
            new PatientId(dto.PatientID),
            new DateOfBirth(dto.DateOfBirth.ToString()),
            dto.Gender,
            new MedicalRecordNumber(dto.MedicalRecordNumber),
            new ContactInformation(dto.ContactInformation),
            new EmergencyContact(dto.EmergencyContact),
            new AppointmentHistory(dto.AppointmentHistory),
            new AllergiesMedicalConditions(dto.AllergiesMedicalConditions));
    }

    public PatientDTO ToDTO(Patient entity)
    {
        return new PatientDTO(entity.Id.Value.ToString(), entity.DateOfBirth.dateOfBirth, entity.Gender,
            entity.MedicalRecordNumber.medicalRecordNumber,
            entity.ContactInformation.contactInformation, entity.EmergencyContact.emergyContact,
            entity.AppointmentHistory.appointementHistory,
            entity.AllergiesMedicalConditions.allergiesMedicalConditions);
    }

    public Patient toEntity(PatientDTO createDto)
    {
        throw new NotImplementedException();
    }
}