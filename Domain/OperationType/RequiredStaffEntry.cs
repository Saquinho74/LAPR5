using System;

namespace DDDNetCore.Domain.OperationType
{
    public class RequiredStaffEntry
    {
        public string Value { get; private set; }

        public RequiredStaffEntry(string value)
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
}