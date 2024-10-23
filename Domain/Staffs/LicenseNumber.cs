using DDDNetCore.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDNetCore.Domain.Staff;

public class LicenseNumber : IValueObject
{
    public string Value { get; private set; }

    public LicenseNumber(string value)
    {
        Value = value;
    }
}