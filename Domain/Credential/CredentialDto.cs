using System;
using DDDNetCore.Domain.Credential;

namespace DDDNetCore.Domain.Credential
{
    public class CredentialDto
    {
        public String Id { get; set; }
        public String Username { get; set; } // Propriedade para armazenar o nome de usuário
        public String Email { get; set; } // Propriedade para armazenar o email
        public String UserStatus { get; set; } // Propriedade para armazenar o status do usuário
        public String UserRole { get; set; } // Propriedade para armazenar o papel do usuário
    }
}