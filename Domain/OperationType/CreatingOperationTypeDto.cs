using System;

namespace DDDNetCore.Domain.OperationType
{
    public class CreatingOperationTypeDto
    {
        public OperationalTypeName OperationalTypeName { get; set; }
        public RequiredStaffEntry RequiredStaffEntry { get; set; }
        public EstimatedDuration EstimatedDuration { get; set; }

    }
}