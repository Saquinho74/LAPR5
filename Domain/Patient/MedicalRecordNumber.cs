using System;

namespace DDDNetCore.Domain.Families;

public class MedicalRecordNumber
{
    
    public MedicalRecordNumber()
    {
    }
    public MedicalRecordNumber(string dtoMedicalRecordNumber)
    {
        this.medicalRecordNumber = medicalRecordNumber;

    }

    public String medicalRecordNumber { get; private set; }
}