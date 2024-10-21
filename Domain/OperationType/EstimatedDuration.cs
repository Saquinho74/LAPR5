using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.OperationType
{
    public class EstimatedDuration : IValueObject
    {
        public int DurationInMinutes { get; private set; } // Duração estimada em minutos

        // Construtor protegido para uso por frameworks de persistência (ex: EF Core)
        protected EstimatedDuration() { }

        // Construtor para criar um novo EstimatedDuration
        public EstimatedDuration(int durationInMinutes)
        {
            if (durationInMinutes <= 0)
                throw new ArgumentException("Duration in minutes must be greater than 0.", nameof(durationInMinutes));

            DurationInMinutes = durationInMinutes;
        }

        // Override do método Equals para garantir comparação de Value Objects
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (EstimatedDuration)obj;

            return DurationInMinutes == other.DurationInMinutes;
        }

        // Override do método GetHashCode para manter a consistência
        public override int GetHashCode()
        {
            return HashCode.Combine(DurationInMinutes);
        }

        // Override do método ToString para facilitar a depuração
        public override string ToString()
        {
            return $"{DurationInMinutes} minutes";
        }
    }
}

