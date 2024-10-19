using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Operation

{
    public class Operation : Entity<OperationId>, IAggregateRoot
    {
     
        public string Description { get;  private set; }

        public bool Active{ get;  private set; }

        private Operation()
        {
            this.Active = true;
        }

        public Operation(string description)
        {
            this.Id = new OperationId(Guid.NewGuid());
            this.Description = description;
            this.Active = true;
        }

        public void ChangeDescription(string description)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the description to an inactive operation.");
            this.Description = description;
        }
        public void MarkAsInative()
        {
            this.Active = false;
        }
    }
}