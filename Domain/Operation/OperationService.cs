using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Operation
{
    public class OperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationRepository _repo;

        public OperationService(IUnitOfWork unitOfWork, IOperationRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<OperationDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<OperationDto> listDto = list.ConvertAll<OperationDto>(cat => new OperationDto{Id = cat.Id.AsGuid(), Description = cat.Description, OperationType = cat.Type, Deadline = cat.Deadline});

            return listDto;
        }

        public async Task<OperationDto> GetByIdAsync(OperationId id)
        {
            var cat = await this._repo.GetByIdAsync(id);
            
            if(cat == null)
                return null;

            return new OperationDto{Id = cat.Id.AsGuid(), Description = cat.Description, OperationType = cat.Type, Deadline = cat.Deadline};
        }

        public async Task<OperationDto> AddAsync(CreatingOperationDto dto)
        {
            var operation = new Operation(dto.Description,dto.Priority, dto.Deadline, dto.OperationType);

            await this._repo.AddAsync(operation);

            await this._unitOfWork.CommitAsync();

            return new OperationDto { Id = operation.Id.AsGuid(), Description = operation.Description, OperationType = operation.Type, Deadline = operation.Deadline };
        }

        public async Task<OperationDto> UpdateAsync(OperationDto dto)
        {
            var category = await this._repo.GetByIdAsync(new OperationId(dto.Id)); 

            if (category == null)
                return null;   

            // change all field
            category.ChangeDescription(dto.Description);
            
            await this._unitOfWork.CommitAsync();

            return new OperationDto { Id = category.Id.AsGuid(), Description = category.Description , OperationType = category.Type, Deadline = category.Deadline };
        }

        public async Task<OperationDto> InactivateAsync(OperationId id)
        {
            var category = await this._repo.GetByIdAsync(id); 

            if (category == null)
                return null;   

            // change all fields
            
            await this._unitOfWork.CommitAsync();

            return new OperationDto { Id = category.Id.AsGuid(), Description = category.Description, OperationType = category.Type, Deadline = category.Deadline };
        }

         public async Task<OperationDto> DeleteAsync(OperationId id)
        {
            var category = await this._repo.GetByIdAsync(id); 

            if (category == null)
                return null;   

            if (category.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active category.");
            
            this._repo.Remove(category);
            await this._unitOfWork.CommitAsync();

            return new OperationDto { Id = category.Id.AsGuid(), Description = category.Description, OperationType = category.Type, Deadline = category.Deadline };
        }
    }
}