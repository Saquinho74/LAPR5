using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Categories;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.OperationType
{
    public class OperationTypeService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationTypeRepository _repo;

        public OperationTypeService(IUnitOfWork unitOfWork, IOperationTypeRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }
        
        public async Task<List<OperationTypeDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<OperationTypeDto> listDto = list.ConvertAll<OperationTypeDto>(cat => new OperationTypeDto{Id = cat.Id.AsGuid(), OperationalTypeName = cat.OperationalTypeName, RequiredStaffEntry = cat.RequiredStaffEntry, EstimatedDuration = cat.EstimatedDuration});

            return listDto;
        }

        public async Task<OperationTypeDto> GetByIdAsync(OperationTypeId id)
        {
            var cat = await this._repo.GetByIdAsync(id);
            
            if(cat == null)
                return null;

            return new OperationTypeDto{Id = cat.Id.AsGuid(), OperationalTypeName = cat.OperationalTypeName, RequiredStaffEntry = cat.RequiredStaffEntry, EstimatedDuration = cat.EstimatedDuration};
        }

        public async Task<OperationTypeDto> AddAsync(CreatingOperationTypeDto dto)
        {
            var operationType = new OperationType(dto.OperationalTypeName, dto.RequiredStaffEntry, dto.EstimatedDuration);

            await this._repo.AddAsync(operationType);

            await this._unitOfWork.CommitAsync();

            return new OperationTypeDto { Id = operationType.Id.AsGuid(), OperationalTypeName = operationType.OperationalTypeName, RequiredStaffEntry = operationType.RequiredStaffEntry, EstimatedDuration = operationType.EstimatedDuration };
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

            return new OperationTypeDto { Id = operationType.Id.AsGuid(), OperationalTypeName = operationType.OperationalTypeName, RequiredStaffEntry = operationType.RequiredStaffEntry, EstimatedDuration = operationType.EstimatedDuration };
        }

        public async Task<OperationTypeDto> InactivateAsync(OperationTypeId id)
        {
            var operationType = await this._repo.GetByIdAsync(id); 

            if (operationType == null)
                return null;   

            // change all fields
            operationType.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new OperationTypeDto { Id = operationType.Id.AsGuid(), OperationalTypeName = operationType.OperationalTypeName, RequiredStaffEntry = operationType.RequiredStaffEntry, EstimatedDuration = operationType.EstimatedDuration };
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

            return new OperationTypeDto { Id = operationType.Id.AsGuid(), OperationalTypeName = operationType.OperationalTypeName, RequiredStaffEntry = operationType.RequiredStaffEntry, EstimatedDuration = operationType.EstimatedDuration };
        }
        
    }
}