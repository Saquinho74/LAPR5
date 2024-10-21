using DDDNetCore.Domain.Operation;

namespace DDDNetCore.Mappers;

public class IOperationMapper
{
    public interface IOperationTypeMapper : IMapper<Operation,OperationDto,CreatingOperationDto> {}

}