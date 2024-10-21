using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.SurgeryRoom
{
    public class Capacity : IValueObject
    {
        public int Value { get; private set; }

        // Define a valid range for capacity values (e.g., between 1 and 1000)
        private const int MinValue = 1;
        private const int MaxValue = 1000;

        // Constructor to create a valid Capacity object
        public Capacity(int value)
        {
            if (value < MinValue || value > MaxValue)
                throw new BusinessRuleValidationException($"Capacity must be between {MinValue} and {MaxValue}.");
            
            this.Value = value;
        }

        // Optional: A static method to create a default capacity if needed
        public static Capacity Default()
        {
            return new Capacity(MinValue); // Default capacity could be the minimum value
        }

        // Override equality checks to treat the capacity as a value object
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Capacity)obj;
            return Value == other.Value;
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
    }
}