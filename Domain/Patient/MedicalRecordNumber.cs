using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

namespace DDDNetCore.Domain.Families;

public class MedicalRecordNumber
{
    public MedicalRecordNumber(int dtoMedicalRecordNumber)
    {
        this.medicalRecordNumber = medicalRecordNumber;

    }

    public int medicalRecordNumber { get; private set; }
}