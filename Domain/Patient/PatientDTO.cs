using System;
using System.Collections.Generic;
using DDDNetCore.Domain.Families;

namespace DDDNetCore.Domain.Patient;

public class PatientDTO
{
    public string PatientID { get; set; }
    public DateTime DateOfBirth { get;  set; }
    public Gender Gender { get;  set; }
    public int MedicalRecordNumber { get;  set; }
    public string ContactInformation { get;  set; }
    public string EmergencyContact { get;  set; }
    public List<string> AppointmentHistory { get;  set; }
    public List<string> AllergiesMedicalConditions { get;  set; }

    public PatientDTO(string patientId, DateTime dateOfBirth, Gender gender, int medicalRecordNumber, string contactInformation, string emergencyContact, List<string> appointmentHistory, List<string> allergiesMedicalConditions)
    {
        PatientID = patientId;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        MedicalRecordNumber = medicalRecordNumber;
        ContactInformation = contactInformation;
        EmergencyContact = emergencyContact;
        AppointmentHistory = appointmentHistory;
        AllergiesMedicalConditions = allergiesMedicalConditions;
    }
}