namespace DDDNetCore.Domain.Patient;

public class PatientDto
{
    public string PatientId { get; set; }
    public string DateOfBirth { get;  set; }
    public string Gender { get;  set; }
    public string MedicalRecordNumber { get;  set; }
    public string ContactInformation { get;  set; }
    public string EmergencyContact { get;  set; }
    public string AppointmentHistory { get;  set; }
    public string AllergiesMedicalConditions { get;  set; }

    
}