using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Credential
{
    public class Username : IValueObject
    {
        public string Value { get; private set; }

        public Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Username cannot be null or empty.", nameof(value));

            // Validação adicional do formato do username
            if (value.Length < 3 || value.Length > 20)
                throw new ArgumentException("Username must be between 3 and 20 characters long.", nameof(value));

            // Exemplos de validação de caracteres (opcional)
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-Z0-9_]+$"))
                throw new ArgumentException("Username can only contain letters, numbers, and underscores.", nameof(value));

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
            if (obj is Username username)
                return Value == username.Value;

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        // Sobrecarga de operadores
        public static bool operator ==(Username left, Username right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Username left, Username right)
        {
            return !Equals(left, right);
        }
    }
}