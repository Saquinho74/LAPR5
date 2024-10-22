using System;

namespace DDDNetCore.Domain.OperationType
{
    public class OperationTypeDto
    {
        public string Id { get; set; }

        public string OperationTypeName { get; set; }
        
        public string RequiredStaffEntry { get; set; }

        public string EstimatedDuration { get; set; }
    }
}