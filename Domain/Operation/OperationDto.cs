using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Operation
{
    public class OperationDto
    {
        public string Id { get; set; }

        public string Description { get; set; }
        
        public string Priority { get; set; }
        
        public string OperationTypeId { get; set; }
        
        public string Deadline { get; set; }
        
        
    }
}