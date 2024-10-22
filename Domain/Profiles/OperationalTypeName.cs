using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Profile
{
    public class OperationalTypeName : IValueObject
    {
        public string Value { get; private set; }

        // Define the minimum and maximum length for a valid operational type name
        private const int MinLength = 3;
        private const int MaxLength = 100;

        // Constructor to create a valid OperationalTypeName object
        public OperationalTypeName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Operational type name cannot be null or empty.");
            }

            if (value.Length < MinLength || value.Length > MaxLength)
            {
                throw new ArgumentException($"Operational type name must be between {MinLength} and {MaxLength} characters.");
            }

            Value = value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        // Override the ToString method for easy display
        public override string ToString()
        {
            return Value;
        }

        // Optional: Add equality check for value objects
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            OperationalTypeName other = (OperationalTypeName)obj;
            return Value == other.Value;
        }
    }
}