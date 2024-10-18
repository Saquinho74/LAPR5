using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Categories;
using DDDSample1.Domain.Shared;
using DDDSample1.Mappers;

namespace DDDSample1.Domain.OperationType
{
    public class OperationTypeService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationTypeRepository _repo;
        private readonly IOperationTypeMapper _mapper;

        public OperationTypeService(IUnitOfWork unitOfWork, IOperationTypeRepository repo,IOperationTypeMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            this._mapper = mapper;
        }
        
        public async Task<List<OperationTypeDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<OperationTypeDto> listDto = list.ConvertAll<OperationTypeDto>(cat => _mapper.toDto(cat));

            return listDto;
        }

        public async Task<OperationTypeDto> GetByIdAsync(OperationTypeId id)
        {
            var cat = await this._repo.GetByIdAsync(id);
            
            if(cat == null)
                return null;

            return _mapper.toDto(cat);
        }

        public async Task<OperationTypeDto> AddAsync(CreatingOperationTypeDto dto)
        {
            var operationType = new OperationType(Guid.NewGuid().ToString(), dto.OperationalTypeName, dto.RequiredStaffEntry, dto.EstimatedDuration);

            await this._repo.AddAsync(operationType);

            await this._unitOfWork.CommitAsync();

            return _mapper.toDto(operationType);
        }

        public async Task<OperationTypeDto> UpdateAsync(OperationTypeDto dto)
        {
            var operationType = await this._repo.GetByIdAsync(new OperationTypeId(dto.Id)); 

            if (operationType == null)
                return null;   

            // change all field
            operationType.ChangeOperationalTypeName(dto.OperationalTypeName);
            operationType.ChangeRequiredStaffEntry(dto.RequiredStaffEntry);
            operationType.ChangeEstimatedDuration(dto.EstimatedDuration);
            
            await this._unitOfWork.CommitAsync();

            return _mapper.toDto(operationType);
        }

        public async Task<OperationTypeDto> InactivateAsync(OperationTypeId id)
        {
            var operationType = await this._repo.GetByIdAsync(id); 

            if (operationType == null)
                return null;   

            // change all fields
            operationType.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return _mapper.toDto(operationType);
        }

         public async Task<OperationTypeDto> DeleteAsync(OperationTypeId id)
        {
            var operationType = await this._repo.GetByIdAsync(id); 

            if (operationType == null)
                return null;   

            if (operationType.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active category.");
            
            this._repo.Remove(operationType);
            await this._unitOfWork.CommitAsync();

            return _mapper.toDto(operationType);
        }
        
    }
}