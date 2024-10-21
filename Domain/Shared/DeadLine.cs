using System;

namespace DDDNetCore.Domain.Shared
{
    public class Deadline
    {
        public DateTime Value { get; private set; }

        // Construtor protegido para uso pelo EF Core
        protected Deadline() { }

        public Deadline(DateTime value)
        {
            if (value <= DateTime.Now)
                throw new ArgumentException("Deadline must be a future date.", nameof(value));

            Value = value;
        }
    }
}