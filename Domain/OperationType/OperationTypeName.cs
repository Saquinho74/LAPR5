using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.OperationType;

public class OperationTypeName : IValueObject
{
    public string Value { get; private set; }

    public OperationTypeName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Description cannot be null or empty.", nameof(value));

        Value = value;
    }

    // Optional: Override ToString for easier debugging and logging
    public override string ToString()
    {
        return Value;
    }
}