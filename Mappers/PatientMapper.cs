using System;
using System.Collections.Generic;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Patient;
using DDDSample1.Domain.Patients;
using DDDNetCore.Domain.Shared;


namespace DDDNetCore.Mappers
{
    public class PatientMapper
    {

        public static PatientDto ToDTO(Patient entity)
        {
            return new PatientDto
            {
                PatientId = entity.Id.Value.ToString(),
                DateOfBirth = entity.DateOfBirth.ToString(), // Parse DateOfBirth back to DateTime
                Gender = entity.Gender.ToString(),
                MedicalRecordNumber = entity.MedicalRecordNumber.ToString(),
                ContactInformation = entity.ContactInformation.ToString(),
                EmergencyContact = entity.EmergencyContact.ToString(),
                AppointmentHistory = entity.AppointmentHistory.ToString(),
                AllergiesMedicalConditions = entity.AllergiesMedicalConditions.ToString(),
            };
        }

        public static List<PatientDto> toDTOList(List<Patient> patients)
        {
            return patients.ConvertAll(entity => new PatientDto
            {
                PatientId = entity.Id.Value.ToString(),
                DateOfBirth = entity.DateOfBirth.ToString(), // Parse DateOfBirth back to DateTime
                Gender = entity.Gender.ToString(),
                MedicalRecordNumber = entity.MedicalRecordNumber.ToString(),
                ContactInformation = entity.ContactInformation.ToString(),
                EmergencyContact = entity.EmergencyContact.ToString(),
                AppointmentHistory = entity.AppointmentHistory.ToString(),
                AllergiesMedicalConditions = entity.AllergiesMedicalConditions.ToString(),
            });

            {
            }
        }

        // Método para converter de PatientDto para Patient
        public static Patient toDomain(PatientDto dto)
        {
            Gender gender = (Gender)Enum.Parse(typeof(Gender), dto.Gender, true);

            return new Patient(
                new PatientId(dto.PatientId), // Assuming PatientID is a string
                new DateOfBirth(dto.DateOfBirth.ToString()),
                gender,
                new MedicalRecordNumber(dto.MedicalRecordNumber),
                new ContactInformation(dto.ContactInformation),
                new EmergencyContact(dto.EmergencyContact),
                new AppointmentHistory(dto.AppointmentHistory),
                new AllergiesMedicalConditions(dto.AllergiesMedicalConditions)
            );
        }

        public static List<Patient> toDomainList(List<PatientDto> dtos)
        {
            return dtos.ConvertAll(dto => toDomain(dto));
        }
    }
}