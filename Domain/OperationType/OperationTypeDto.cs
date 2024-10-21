using System;

namespace DDDNetCore.Domain.OperationType
{
    public class OperationTypeDto
    {
        public Guid Id { get; set; }
        public OperationalTypeName OperationalTypeName { get; set; }
        public RequiredStaffEntry RequiredStaffEntry { get; set; }
        public EstimatedDuration EstimatedDuration { get; set; }
        public bool Active { get; set; }
    }
}