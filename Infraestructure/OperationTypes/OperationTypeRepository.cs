﻿using DDDNetCore.Domain.OperationType;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.OperationTypes
{
    public class OperationTypeRepository : BaseRepository<OperationType, OperationTypeId>, IOperationTypeRepository
    {
      
        public OperationTypeRepository(DddSample1DbContext context):base(context.OperationTypes)
        {
            
        }

    }
}