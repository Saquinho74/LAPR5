using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Families;

namespace DDDNetCore.DTO;

public class PatientDTO(PatientID entityPatientId, DateOfBirth entityDateOfBirth, Gender entityGender, MedicalRecordNumber entityMedicalRecordNumber, ContactInformation entityContactInformation, EmergencyContact entityEmergencyContact, AppointmentHistory entityAppointmentHistory, AllergiesMedicalConditions entityAllergiesMedicalConditions)
{
    public PatientID patientID { get; set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public MedicalRecordNumber MedicalRecordNumber { get; private set; }
    public ContactInformation ContactInformation { get; private set; }
    public EmergencyContact EmergencyContact { get; private set; }
    public AppointmentHistory AppointmentHistory { get; private set; }
    public AllergiesMedicalConditions AllergiesMedicalConditions { get; private set; }
    
}