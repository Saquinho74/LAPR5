using System;

namespace DDDNetCore.Domain.Shared
{
    public class PhoneNumber : IValueObject
    {
        public int Value { get; private set; }

        // Define the length for a valid phone number
        private const int MinDigits = 9;
        private const int MaxDigits = 9;

        // Constructor to create a valid PhoneNumber object
        public PhoneNumber(int value)
        {
            // Ensure the number is exactly 9 digits
            if (value.ToString().Length != MinDigits)
            {
                throw new ArgumentException($"Phone number must be exactly {MinDigits} digits.");
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
            return Value.ToString();
        }

        // Optional: Add equality check for value objects
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PhoneNumber other = (PhoneNumber)obj;
            return Value == other.Value;
        }
    }
}