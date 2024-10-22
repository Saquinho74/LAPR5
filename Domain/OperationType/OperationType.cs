using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.OperationType
{
    public class OperationType : Entity<OperationTypeId>, IAggregateRoot
    {
        public OperationTypeName OperationTypeName { get; private set; }
        
        public RequiredStaffEntry RequiredStaffEntry { get; private set; }
        
        public EstimatedDuration EstimatedDuration { get; private set; }
        
        public bool Active{ get;  private set; }
        
        public OperationType() { }
        
        public OperationType(OperationTypeName operationTypeName, RequiredStaffEntry requiredStaffEntry, EstimatedDuration estimatedDuration)
        {
            this.Id = new OperationTypeId(Guid.NewGuid()); // Generate a new unique ID
            this.OperationTypeName =new OperationTypeName(operationTypeName.Value); // Use the OperationalTypeName value object
            this.RequiredStaffEntry = new RequiredStaffEntry(requiredStaffEntry.Value);
            this.EstimatedDuration = new EstimatedDuration(estimatedDuration.Value); // Use the EstimatedDuration value object
            this.Active = true;
        }
        
        public void ChangeOperationalTypeName(OperationTypeName operationTypeName)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the operational type name to an inactive operation type.");
            this.OperationTypeName = operationTypeName;
        }
        
        
        public void ChangeRequiredStaffEntry(RequiredStaffEntry requiredStaffEntry)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the required staff entry to an inactive operation type.");
            this.RequiredStaffEntry = RequiredStaffEntry;
        }
        
        public void ChangeEstimatedDuration(EstimatedDuration estimatedDuration)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the estimated duration to an inactive operation type.");
            this.EstimatedDuration = estimatedDuration;
        }
        
        public void MarkAsInative()
        {
            this.Active = false;
        }

    }
}