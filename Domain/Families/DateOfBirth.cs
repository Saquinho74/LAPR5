using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

namespace DDDNetCore.Domain.Families;

public class DateOfBirth
{
    public List<JSType.String> dateOfBirth { get; private set; }

    public DateOfBirth()
    {
        this.dateOfBirth = dateOfBirth;
    }

    public void addDateOfBirth(JSType.String dateOfBirth)
    {
        this.dateOfBirth.Add(dateOfBirth);
        {

        }
    }
}
