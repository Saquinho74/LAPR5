using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class AllergiesMedicalConditions : IValueObject
{
    public List<JSType.String> allergiesMedicalConditions { get; private set; }
    
    public AllergiesMedicalConditions()
    {
        this.allergiesMedicalConditions = allergiesMedicalConditions;
    }

    public void addAllergiesMedicalConditions(JSType.String allergiesMedicalConditions)
    {
        this.allergiesMedicalConditions.Add(allergiesMedicalConditions);
    }
}