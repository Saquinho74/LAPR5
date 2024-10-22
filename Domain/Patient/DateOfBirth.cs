using System;

namespace DDDNetCore.Domain.Patient;

public class DateOfBirth
{
    public DateTime dateOfBirth { get; private set; }

    public DateOfBirth(string dateOfBirth)
    {
        this.dateOfBirth = DateTime.Parse(dateOfBirth);
        ;
    }

    public DateOfBirth()
    {
        
    }
    
}