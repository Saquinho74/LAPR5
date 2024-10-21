using System;
using System.Text.RegularExpressions;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Credential
{
    public class Email : IValueObject
    {
        public string Value { get; private set; }

        // Construtor protegido para uso pelo EF Core
        protected Email() { }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be null or empty.", nameof(value));
                
            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email format.", nameof(value));

            Value = value;
        }

        // Método para validar o formato do email
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public override string ToString() => Value;

        public  bool Equals(object obj)
        {
            if (obj is Email otherEmail)
            {
                return string.Equals(Value, otherEmail.Value, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public  int GetHashCode() => Value?.ToLowerInvariant().GetHashCode() ?? 0;
    }
}