using System;

namespace DDDNetCore.Domain.OperationType
{
    public class CreatingOperationTypeDto
    {
        public OperationTypeName OperationTypeName { get; set; }
        
        public RequiredStaffEntry RequiredStaffEntry { get; set; }
        
        public EstimatedDuration EstimatedDuration { get; set; }
        
        
        public CreatingOperationTypeDto(OperationTypeName operationTypeName, RequiredStaffEntry requiredStaffEntry, EstimatedDuration estimatedDuration)
        {
            this.OperationTypeName = operationTypeName;
            this.RequiredStaffEntry =requiredStaffEntry;
            this.EstimatedDuration = estimatedDuration;
        }
    }
}