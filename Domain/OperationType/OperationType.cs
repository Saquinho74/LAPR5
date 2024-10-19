using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.OperationType
{
    public class OperationType : Entity<OperationTypeId>, IAggregateRoot
    {
        public string OperationalTypeName { get; private set; }
        
        public string RequiredStaffEntry { get; private set; }
        
        public string EstimatedDuration { get; private set; }
        
        public bool Active{ get;  private set; }
        
        public OperationType(string code, string operationalTypeName, string requiredStaffEntry, string estimatedDuration)
        {
            this.Id = new OperationTypeId(code);
            this.OperationalTypeName = operationalTypeName;
            this.RequiredStaffEntry = requiredStaffEntry;
            this.EstimatedDuration = estimatedDuration;
            this.Active = true;
        }
        
        public OperationType(string operationalTypeName, string requiredStaffEntry, string estimatedDuration)
        {
            this.OperationalTypeName = operationalTypeName;
            this.RequiredStaffEntry = requiredStaffEntry;
            this.EstimatedDuration = estimatedDuration;
            this.Active = true;
        }
        
        public void ChangeOperationalTypeName(string operationalTypeName)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the operational type name to an inactive operation type.");
            this.OperationalTypeName = operationalTypeName;
        }
        
        
        public void ChangeRequiredStaffEntry(string RequiredStaffEntry)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the required staff entry to an inactive operation type.");
            this.RequiredStaffEntry = RequiredStaffEntry;
        }
        
        public void ChangeEstimatedDuration(string estimatedDuration)
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