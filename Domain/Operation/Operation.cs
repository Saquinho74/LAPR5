using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Operation
{
    public class Operation : Entity<OperationId>, IAggregateRoot
    {
        public string Description { get; private set; }
        public Priority Priority { get; private set; }
        public Deadline Deadline { get; private set; }
        public OperationType.OperationType Type { get; private set; }
        public bool Active { get; private set; }

        // Private constructor for ORM (e.g., EF Core)
        private Operation()
        {
            this.Active = true; // Default to active when created
        }

        // Constructor to initialize the Operation entity with required parameters
        public Operation(string description, Priority priorityValue, Deadline deadlineValue, OperationType.OperationType type)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
                
            this.Id = new OperationId(Guid.NewGuid()); // Generate a new unique ID
            this.Description = description;
            this.Priority = new Priority(priorityValue.Value); // Use the Priority value object
            this.Deadline = new Deadline(deadlineValue.Value); // Use the Deadline value object
            this.Type = type ?? throw new ArgumentNullException(nameof(type)); // Ensure type is not null
            this.Active = true; // Set operation as active
        }

        // Method to change the description of the operation
        public void ChangeDescription(string description)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the description of an inactive operation.");
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            this.Description = description;
        }

        // Method to change the priority of the operation
        public void ChangePriority(int priorityValue)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the priority of an inactive operation.");
            this.Priority = new Priority(priorityValue); // Update priority using the value object
        }

        // Method to change the deadline of the operation
        public void ChangeDeadline(DateTime newDeadline)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the deadline of an inactive operation.");
            this.Deadline = new Deadline(newDeadline); // Update deadline using the value object
        }

        // Method to mark the operation as inactive
        public void MarkAsInactive()
        {
            this.Active = false;
        }
    }
}
