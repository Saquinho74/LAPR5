using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Mappers;

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
            
            
            var dtoReturn = CredentialMapper.toDTOList(credentials);

            return dtoReturn;
        }

        // Método para obter uma credencial por ID
        public async Task<CredentialDto> GetByIdAsync(CredentialId id)
        {
            var credential = await _repo.GetByIdAsync(id);
            
            if (credential == null)
                return null;

            
            var dtoReturn = CredentialMapper.toDTO(credential);
            return dtoReturn;
        }

        // Método para adicionar uma nova credencial
        public async Task<CredentialDto> AddAsync(CreatingCredentialDto dto)
        {
            var credential = new Credential(new Username(dto.Username.Value), new Email(dto.Email.Value), dto.UserStatus, dto.UserRole);

            await _repo.AddAsync(credential);
            await _unitOfWork.CommitAsync();

            
            var dtoReturn = CredentialMapper.toDTO(credential);
            return dtoReturn;
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

             
            var dtoReturn = CredentialMapper.toDTO(credential);
            return dtoReturn;
        }

        // Método para deletar uma credencial
        public async Task<CredentialDto> DeleteAsync(CredentialId id)
        {
            var credential = await _repo.GetByIdAsync(id);

            if (credential == null)
                return null;

            _repo.Remove(credential);
            await _unitOfWork.CommitAsync();


            var dtoReturn = CredentialMapper.toDTO(credential);
            return dtoReturn;
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


            var dtoReturn = CredentialMapper.toDTO(credential);
            return dtoReturn;
        }
    }
}
