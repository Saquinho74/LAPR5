using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Operation
{
    public class OperationDto
    {
        public Guid Id { get; set; }

        public OperationDescription Description { get; set; }
        
        public OperationType.OperationType Type { get; set; }
        
        public Deadline Deadline { get; set; }
        
        public OperationType.OperationType OperationType { get; set; }
        
        
    }
}