using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.OperationType
{
    public class RequiredStaffEntry : IValueObject
    {
        public string Speciality { get; private set; } // A especialidade requerida
        public int RequiredStaff { get; private set; } // Número de pessoal necessário

        // Construtor protegido para uso por frameworks de persistência (ex: EF Core)
        protected RequiredStaffEntry() { }

        // Construtor para criar um novo RequiredStaffEntry
        public RequiredStaffEntry(string speciality, int requiredStaff)
        {
            if (string.IsNullOrWhiteSpace(speciality))
                throw new ArgumentException("Speciality cannot be null or empty.", nameof(speciality));

            if (requiredStaff <= 0)
                throw new ArgumentException("RequiredStaff must be greater than 0.", nameof(requiredStaff));

            Speciality = speciality;
            RequiredStaff = requiredStaff;
        }

        // Override do método Equals para garantir comparação de Value Objects
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (RequiredStaffEntry)obj;

            return Speciality == other.Speciality && RequiredStaff == other.RequiredStaff;
        }

        // Override do método GetHashCode para manter a consistência
        public override int GetHashCode()
        {
            return HashCode.Combine(Speciality, RequiredStaff);
        }

        // Override do método ToString para facilitar a depuração
        public override string ToString()
        {
            return $"{Speciality}: {RequiredStaff} staff required";
        }
    }
}
