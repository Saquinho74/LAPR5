using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Staff;

public class Specialization : IValueObject
{
    public string Value { get; private set; }
    public Specialization(string value)
    {
        Value = value;
    }
}