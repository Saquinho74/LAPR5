using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Mappers;

namespace DDDNetCore.Domain.Operation
{
    public class OperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationRepository _repo;

        public OperationService(IUnitOfWork unitOfWork, IOperationRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        // Método para obter todas as operações
        public async Task<List<OperationDto>> GetAllAsync()
        {
            var operations = await _repo.GetAllAsync();
            
            // Conversão das operações em DTOs
            var listDto = OperationMapper.toDTOList(operations);

            return listDto;
        }

        // Método para obter uma operação por ID
        public async Task<OperationDto> GetByIdAsync(OperationId id)
        {
            var operation = await _repo.GetByIdAsync(id);
            
            if (operation == null)
                return null;

            var dtoReturn = OperationMapper.toDTO(operation);

            return dtoReturn;
        }

        // Método para adicionar uma nova operação
        public async Task<OperationDto> AddAsync(CreatingOperationDto dto)
        {
            var operation = new Operation(
                new OperationDescription(dto.Description.Value), // Supondo que Description é um Value Object
                new Priority(dto.Priority.Value), // Supondo que Priority é um Value Object
                new Deadline(dto.Deadline.Value), // Deadline como um Value Object
                dto.OperationType
            );

            await _repo.AddAsync(operation);
            await _unitOfWork.CommitAsync();
            
            var dtoReturn = OperationMapper.toDTO(operation);

            return dtoReturn;

           
        }

        // Método para atualizar uma operação existente
        public async Task<OperationDto> UpdateAsync(OperationDto dto)
        {
            var operation = await _repo.GetByIdAsync(new OperationId(dto.Id));

            if (operation == null)
                return null;

            // Atualiza as informações da operação
            operation.ChangeDescription(new OperationDescription(dto.Description)); // Atualizando a descrição da operação

            await _unitOfWork.CommitAsync();
            
            var dtoReturn = OperationMapper.toDTO(operation);

            return dtoReturn;
        }

        // Método para inativar uma operação
        public async Task<OperationDto> InactivateAsync(OperationId id)
        {
            var operation = await _repo.GetByIdAsync(id);

            if (operation == null)
                return null;

            // Aqui você deve implementar a lógica para inativar a operação

            await _unitOfWork.CommitAsync();

            var dtoReturn = OperationMapper.toDTO(operation);

            return dtoReturn;
        }

        // Método para deletar uma operação
        public async Task<OperationDto> DeleteAsync(OperationId id)
        {
            var operation = await _repo.GetByIdAsync(id);

            if (operation == null)
                return null;

            if (operation.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active operation.");

            _repo.Remove(operation);
            await _unitOfWork.CommitAsync();

            var dtoReturn = OperationMapper.toDTO(operation);

            return dtoReturn;
        }
    }
}
