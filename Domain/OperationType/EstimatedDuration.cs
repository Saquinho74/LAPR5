using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.OperationType
{
    public class EstimatedDuration
    {
        public string Value { get; private set; }
        

        // Constructor to create a valid Priority object
        public EstimatedDuration(string value)
        
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleValidationException($"Priority must a number.");
            
            this.Value = value;
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