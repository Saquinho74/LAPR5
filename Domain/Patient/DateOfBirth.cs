using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

namespace DDDNetCore.Domain.Families;

public class DateOfBirth
{
    public DateTime dateOfBirth { get; private set; }

    public DateOfBirth(string dtoDateOfBirth)
    {
        this.dateOfBirth = DateTime.Parse(dtoDateOfBirth);
        ;
    }
}