using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.SurgeryRoom
{
    public class AssignedEquipment : IValueObject
    {
        public string Value { get; private set; }

        // Construtor que inicializa o valor do AssignedEquipment
        public AssignedEquipment(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Assigned Equipment cannot be null or empty.", nameof(value));

            // Validação adicional do formato do Assigned Equipment
            if (value.Length < 2 || value.Length > 100)
                throw new ArgumentException("Assigned Equipment must be between 2 and 100 characters long.", nameof(value));

            // Exemplo de validação de caracteres (opcional, pode ser ajustado conforme a necessidade)
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-Z0-9\s\-]+$"))
                throw new ArgumentException("Assigned Equipment can only contain letters, numbers, spaces, and hyphens.", nameof(value));

            Value = value;
        }

        // Sobrescrever ToString para facilitar a depuração e o registro
        public override string ToString()
        {
            return Value;
        }

        // Implementar a igualdade para objetos de valor
        public override bool Equals(object obj)
        {
            if (obj is AssignedEquipment equipment)
                return Value == equipment.Value;

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        // Sobrecarga de operadores
        public static bool operator ==(AssignedEquipment left, AssignedEquipment right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssignedEquipment left, AssignedEquipment right)
        {
            return !Equals(left, right);
        }
    }
}