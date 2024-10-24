
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Domain.OperationType
{
    public class OperationTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationTypeRepository _repo;
        private readonly IOperationTypeMapper _mapper;

        public OperationTypeService(IUnitOfWork unitOfWork, IOperationTypeRepository repo, IOperationTypeMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            this._mapper = mapper;
        }

        
        // Método para obter todas as operações
        public async Task<List<OperationTypeDto>> GetAllAsync()
        {
            var operationTypes = await _repo.GetAllAsync();
            
            // Conversão das operações em DTOs
            var listDto = OperationTypeMapper.toDTOList(operationTypes);

            return listDto;
        }

        // Método para obter uma operação por ID
        public async Task<OperationTypeDto> AddAsync(CreatingOperationTypeDto dto)
        {
            var operationType = _mapper.toDomain(dto);

            await _repo.AddAsync(operationType);
            await _unitOfWork.CommitAsync();
            
            var dtoReturn = OperationTypeMapper.toDTO(operationType);

            return dtoReturn;

           
        }
        
        // Método para atualizar uma operação existente
        public async Task<OperationTypeDto> UpdateAsync(OperationTypeDto dto)
        {
            var operationType = await _repo.GetByIdAsync(new OperationTypeId(dto.Id));

            
            
            if (operationType == null)
                return null;

            // Atualiza as informações da operação
            operationType.ChangeOperationalTypeName(new OperationTypeName(dto.OperationTypeName)); // Atualizando a descrição da operação
            operationType.ChangeRequiredStaffEntry(new RequiredStaffEntry(dto.RequiredStaffEntry)); // Atualizando a Deadline da operação    
            operationType.ChangeEstimatedDuration(new EstimatedDuration(dto.EstimatedDuration)); // Atualizando a Estimated Duartion da operação
            
            await _unitOfWork.CommitAsync();
            
            var dtoReturn = OperationTypeMapper.toDTO(operationType);

            return dtoReturn;
        }

        // Método para inativar uma tipo operação
        public async Task<OperationTypeDto> InactivateAsync(OperationTypeId id)
        {
            var operationType = await _repo.GetByIdAsync(id);

            if (operationType == null)
                return null;

            // Aqui você deve implementar a lógica para inativar a operação
            operationType.MarkAsInative();
            await _unitOfWork.CommitAsync();

            var dtoReturn = OperationTypeMapper.toDTO(operationType);

            return dtoReturn;
        }

        // Método para deletar uma operação
        public async Task<OperationTypeDto> DeleteAsync(OperationTypeId id)
        {
            var operationType = await _repo.GetByIdAsync(id);

            if (operationType == null)
                return null;
            
            _repo.Remove(operationType);
            await _unitOfWork.CommitAsync();

            var dtoReturn = OperationTypeMapper.toDTO(operationType);

            return dtoReturn;
        }

        public async Task<ActionResult<OperationTypeDto>> GetByIdAsync(OperationTypeId operationTypeId)
        {
            var operationType = await _repo.GetByIdAsync(operationTypeId);

            if (operationType == null)
                return null;

            var dtoReturn = OperationTypeMapper.toDTO(operationType);

            return dtoReturn;
        }
    }
}
