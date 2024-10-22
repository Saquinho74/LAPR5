namespace DDDNetCore.Domain.Patient;

public class MedicalRecordNumber
{
    public MedicalRecordNumber(int dtoMedicalRecordNumber)
    {
        this.medicalRecordNumber = medicalRecordNumber;

    }

    public int medicalRecordNumber { get; private set; }
    
    public MedicalRecordNumber() {  }
}