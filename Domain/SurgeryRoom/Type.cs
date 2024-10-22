using System;

namespace DDDNetCore.Domain.SurgeryRoom;

public class Type
{
    
        public string Value { get; private set; }

        // Construtor que inicializa o valor do Type
        public Type(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Type cannot be null or empty.", nameof(value));

            // Validação adicional do formato do Type
            if (value.Length < 3 || value.Length > 50)
                throw new ArgumentException("Type must be between 3 and 50 characters long.", nameof(value));

            // Exemplo de validação de caracteres (opcional, pode ser ajustado conforme a necessidade)
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$"))
                throw new ArgumentException("Type can only contain letters, numbers, and spaces.", nameof(value));

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
            if (obj is Type type)
                return Value == type.Value;

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    
}