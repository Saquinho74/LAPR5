using System.Collections.Generic;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Patient;

public class AllergiesMedicalConditions : IValueObject
{
    public List<string> allergiesMedicalConditions { get; private set; }

    public AllergiesMedicalConditions()
    {
    }

    public AllergiesMedicalConditions(List<string> allergiesMedicalConditions)
    {
        this.allergiesMedicalConditions = allergiesMedicalConditions;
    }
}