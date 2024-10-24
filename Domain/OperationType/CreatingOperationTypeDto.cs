using System;

namespace DDDNetCore.Domain.OperationType
{
    public class CreatingOperationTypeDto
    {
        public string OperationTypeName { get; set; }
        
        public string RequiredStaffEntry { get; set; }
        
        public string EstimatedDuration { get; set; }
        
        
        public CreatingOperationTypeDto(string operationTypeName, string requiredStaffEntry, string estimatedDuration)
        {
            this.OperationTypeName = operationTypeName;
            this.RequiredStaffEntry =requiredStaffEntry;
            this.EstimatedDuration = estimatedDuration;
        }
    }
}