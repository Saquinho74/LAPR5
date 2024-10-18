using DDDSample1.Domain.OperationType;

namespace DDDSample1.Mappers
{
    public class OperationTypeMapper : IOperationTypeMapper
    {
        public OperationType toDomain(OperationTypeDto dto)
        {
            return new OperationType(dto.Id.ToString(),
                dto.OperationalTypeName, 
                dto.RequiredStaffEntry, 
                dto.EstimatedDuration);
        }

        public OperationTypeDto toDto(OperationType entity)
        {
            return new OperationTypeDto{Id = entity.Id.AsGuid(), 
                OperationalTypeName = entity.OperationalTypeName, 
                RequiredStaffEntry = entity.RequiredStaffEntry, 
                EstimatedDuration = entity.EstimatedDuration, 
                Active = entity.Active
            };
        }

        public OperationType toDomain(CreatingOperationTypeDto createDto)
        {
            return new OperationType(createDto.OperationalTypeName, 
                createDto.RequiredStaffEntry, 
                createDto.EstimatedDuration);
        }
    }
}