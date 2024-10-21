using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Credential
{
    public class CredentialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICredentialRepository _repo;

        public CredentialService(IUnitOfWork unitOfWork, ICredentialRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        // Método para obter todas as credenciais
        public async Task<List<CredentialDto>> GetAllAsync()
        {
            var credentials = await _repo.GetAllAsync();
            
            // Conversão das credenciais em DTOs
            var listDto = credentials.ConvertAll(credential => new CredentialDto 
            { 
                Id = credential.Id.AsGuid().ToString(), // Certificando-se que é uma string
                Username = credential.Username.Value, // Usando a propriedade Value do Username
                Email = credential.Email.Value, // Usando a propriedade Value do Email
                UserStatus = credential.UserStatus.ToString(), // Supondo que UserStatus pode ser convertido para string
                UserRole = credential.UserRole.ToString() // Supondo que UserRole pode ser convertido para string
            });

            return listDto;
        }

        // Método para obter uma credencial por ID
        public async Task<CredentialDto> GetByIdAsync(CredentialId id)
        {
            var credential = await _repo.GetByIdAsync(id);
            
            if (credential == null)
                return null;

            return new CredentialDto 
            { 
                Id = credential.Id.AsGuid().ToString(),
                Username = credential.Username.Value,
                Email = credential.Email.Value,
                UserStatus = credential.UserStatus.ToString(),
                UserRole = credential.UserRole.ToString()
            };
        }

        // Método para adicionar uma nova credencial
        public async Task<CredentialDto> AddAsync(CreatingCredentialDto dto)
        {
            var credential = new Credential(new Username(dto.Username.Value), new Email(dto.Email.Value), dto.UserStatus, dto.UserRole);

            await _repo.AddAsync(credential);
            await _unitOfWork.CommitAsync();

            return new CredentialDto 
            { 
                Id = credential.Id.AsGuid().ToString(),
                Username = credential.Username.Value,
                Email = credential.Email.Value,
                UserStatus = credential.UserStatus.ToString(),
                UserRole = credential.UserRole.ToString()
            };
        }

        // Método para atualizar uma credencial existente
        public async Task<CredentialDto> UpdateAsync(CredentialDto dto)
        {
            var credential = await _repo.GetByIdAsync(new CredentialId(dto.Id));

            if (credential == null)
                return null;

            // Atualiza as informações do usuário
            credential.UpdateUserInfo(new Username(dto.Username), new Email(dto.Email));

            await _unitOfWork.CommitAsync();

            return new CredentialDto 
            { 
                Id = credential.Id.AsGuid().ToString(),
                Username = credential.Username.Value,
                Email = credential.Email.Value,
                UserStatus = credential.UserStatus.ToString(),
                UserRole = credential.UserRole.ToString()
            };
        }

        // Método para deletar uma credencial
        public async Task<CredentialDto> DeleteAsync(CredentialId id)
        {
            var credential = await _repo.GetByIdAsync(id); 

            if (credential == null)
                return null;   

            _repo.Remove(credential);
            await _unitOfWork.CommitAsync();

            return new CredentialDto 
            { 
                Id = credential.Id.AsGuid().ToString(),
                Username = credential.Username.Value,
                Email = credential.Email.Value,
                UserStatus = credential.UserStatus.ToString(),
                UserRole = credential.UserRole.ToString()
            };
        }

        // Método para inativar uma credencial
        public async Task<CredentialDto> InactivateAsync(CredentialId credentialId)
        {
            var credential = await _repo.GetByIdAsync(credentialId);

            if (credential == null)
                return null;

            // Aqui você deve implementar a lógica para inativar a credencial
            credential.Inactivate(); // Supondo que há um método Inactivate na classe Credential
            
            await _unitOfWork.CommitAsync();

            return new CredentialDto
            {
                Id = credential.Id.AsGuid().ToString(),
                Username = credential.Username.Value,
                Email = credential.Email.Value,
                UserStatus = credential.UserStatus.ToString(),
                UserRole = credential.UserRole.ToString()
            };
        }
    }
}
