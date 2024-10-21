namespace DDDNetCore.Domain.Shared

{
    public class Priority : IValueObject
    {
        public int Value { get; private set; }

        // Define a valid range for priority values (e.g., between 1 and 10)
        private const int MinValue = 1;
        private const int MaxValue = 10;

        // Constructor to create a valid Priority object
        public Priority(int value)
        {
            if (value < MinValue || value > MaxValue)
                throw new BusinessRuleValidationException($"Priority must be between {MinValue} and {MaxValue}.");
            
            this.Value = value;
        }

        // Optional: A static method to create a default priority if needed
        public static Priority Default()
        {
            return new Priority(MinValue); // Default priority could be the minimum value
        }

        // Override equality checks to treat the priority as a value object
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Priority)obj;
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