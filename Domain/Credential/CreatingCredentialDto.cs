using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Credential
{
    public class CreatingCredentialDto
    {
        public Username Username { get; set; } // Propriedade para o nome de usuário
        public Email Email { get; set; } // Propriedade para o email do usuário
        public Status UserStatus { get; set; } // Propriedade para o status do usuário
        public Role UserRole { get; set; } // Propriedade para o papel do usuário

        // Construtor que inicializa as propriedades da classe
        public CreatingCredentialDto(Username username, Email email, Status userStatus, Role userRole)
        {
            Username = username;
            Email = email;
            UserStatus = userStatus;
            UserRole = userRole;
        }
    }
}