using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Credential
{
    public class Credential : Entity<CredentialId>, IAggregateRoot
    {
        // Propriedades da credencial
        public Username Username { get; private set; }
        public Email Email { get; private set; }
        public Status UserStatus { get; private set; }
        public Role UserRole { get; private set; }

        // Construtor privado para uso com ORM (ex: EF Core)
        private Credential()
        {
            // Construtor privado, não utilizado diretamente
        }

        // Construtor para inicializar a entidade Credential com parâmetros necessários
        public Credential(Username username, Email email, Status userStatus, Role userRole)
        {
            this.Id = new CredentialId(Guid.NewGuid()); // Gerar um novo ID
            this.Username = username ?? throw new ArgumentNullException(nameof(username), "Username cannot be null.");
            this.Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null.");
            this.UserStatus = userStatus; // O status do usuário
            this.UserRole = userRole; // O papel do usuário
        }

        // Método para atualizar informações do usuário
        public void UpdateUserInfo(Username username, Email email)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username), "Username cannot be null.");
            Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null.");
        }
        
        // Método para atualizar o status do usuário
        public void UpdateUserStatus(Status status)
        {
            UserStatus = status;
        }

        // Método para atualizar o papel do usuário
        public void UpdateUserRole(Role role)
        {
            UserRole = role;
        }

        public void Inactivate()
        {
            throw new NotImplementedException();
        }
    }
}