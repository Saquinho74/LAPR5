using System;

namespace DDDNetCore.Domain.Patient;

public class DateOfBirth
{
    public DateTime DateOfBirthValue { get; private set; }

    public DateOfBirth(string dateOfBirth)
    {
        if (!DateTime.TryParse(dateOfBirth, out DateTime parsedDate))
        {
            throw new ArgumentException("Invalid date format. Please provide a valid date.");
        }

        DateOfBirthValue = parsedDate;
    }
    public DateOfBirth()
    {
        
    }
    
}