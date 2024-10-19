using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Operation
{
    public interface IOperationRepository: IRepository<Operation, OperationId>
    {
    }
}