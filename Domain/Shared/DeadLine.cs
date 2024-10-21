using System;

namespace DDDNetCore.Domain.Shared
{
    public class Deadline : IValueObject
    {
        public DateTime Value { get; private set; }

        // Constructor to create a valid Deadline object
        public Deadline(DateTime deadline)
        {
            if (deadline < DateTime.Now)
                throw new BusinessRuleValidationException("Deadline cannot be in the past.");
            
            this.Value = deadline;
        }

        // Static method to create a deadline with a default time (optional)
        public static Deadline Default()
        {
            return new Deadline(DateTime.Now.AddDays(1)); // Default deadline is 1 day from now
        }

        // Method to check if the deadline has passed
        public bool IsOverdue()
        {
            return DateTime.Now > Value;
        }

        // Override equality checks to treat Deadline as a value object
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Deadline)obj;
            return Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        // Override the ToString method for easy display
        public override string ToString()
        {
            return Value.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}