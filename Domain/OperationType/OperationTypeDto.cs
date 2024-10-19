using System;

namespace DDDNetCore.Domain.OperationType
{
    public class OperationTypeDto
    {
        public Guid Id { get; set; }
        public String OperationalTypeName { get; set; }
        public String RequiredStaffEntry { get; set; }
        public String EstimatedDuration { get; set; }
        public bool Active { get; set; }
    }
}