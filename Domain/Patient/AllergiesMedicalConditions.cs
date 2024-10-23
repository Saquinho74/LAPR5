using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class AllergiesMedicalConditions : IValueObject
{
    public String allergiesMedicalConditions { get; private set; }

    public AllergiesMedicalConditions()
    {
    }

    public AllergiesMedicalConditions(String dtoAllergiesMedicalConditions)
    {
        this.allergiesMedicalConditions = dtoAllergiesMedicalConditions;
    }
}