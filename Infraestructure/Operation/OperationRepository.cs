using DDDNetCore.Domain.Categories;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Operation
{
    public class OperationRepository : BaseRepository<Domain.Operation.Operation, OperationId>, IOperationRepository
    {
    
        public OperationRepository(DddSample1DbContext context):base(context.Operation)
        {
           
        }


    }
}