using System;

namespace DDDSample1.Domain.OperationType
{
    public class CreatingOperationTypeDto
    {
        public String OperationalTypeName { get; set; }
        public String RequiredStaffEntry { get; set; }
        public String EstimatedDuration { get; set; }
        
        public CreatingOperationTypeDto(String operationalTypeName, String requiredStaffEntry, String estimatedDuration)
        {
            this.OperationalTypeName = operationalTypeName;
            this.RequiredStaffEntry = requiredStaffEntry;
            this.EstimatedDuration = estimatedDuration;
        }
    }
}