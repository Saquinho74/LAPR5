using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

namespace DDDNetCore.Domain.Families;

public class MedicalRecordNumber
{
    public List<JSType.String> medicalRecordNumber { get; private set; }

    public MedicalRecordNumber()
    {
        this.medicalRecordNumber = medicalRecordNumber;
    }

    public void addMedicalRecordNumber(JSType.String medicalRecordNumber)
    {
        this.medicalRecordNumber.Add(medicalRecordNumber);
    }
}