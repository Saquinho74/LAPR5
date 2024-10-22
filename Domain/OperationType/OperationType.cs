using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.OperationType
{
    public class OperationType : Entity<OperationTypeId>, IAggregateRoot
    {
        public OperationalTypeName OperationalTypeName { get; private set; }
        
        public RequiredStaffEntry RequiredStaffEntry { get; private set; }
        
        public EstimatedDuration EstimatedDuration { get; private set; }
        
        public bool Active{ get;  private set; }
        
        public OperationType() { }
        
        public OperationType(string code, OperationalTypeName operationalTypeName, RequiredStaffEntry requiredStaffEntry, EstimatedDuration estimatedDuration)
        {
            this.Id = new OperationTypeId(code);
            this.OperationalTypeName = operationalTypeName;
            this.RequiredStaffEntry = requiredStaffEntry;
            this.EstimatedDuration = estimatedDuration;
            this.Active = true;
        }
        
        public OperationType(OperationalTypeName operationalTypeName, RequiredStaffEntry requiredStaffEntry, EstimatedDuration estimatedDuration)
        {
            this.OperationalTypeName = operationalTypeName;
            this.RequiredStaffEntry = requiredStaffEntry;
            this.EstimatedDuration = estimatedDuration;
            this.Active = true;
        }
        
        public void ChangeOperationalTypeName(OperationalTypeName operationalTypeName)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the operational type name to an inactive operation type.");
            this.OperationalTypeName = operationalTypeName;
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