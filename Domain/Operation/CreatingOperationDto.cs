using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Operation
{
    public class CreatingOperationDto
    {
        public string Description { get; set; }
        
        public OperationType.OperationType OperationType { get; set; }
        
        public Priority Priority { get; set; }
        
        public Deadline Deadline { get; set; }
        
        
        


        public CreatingOperationDto(string description, OperationType.OperationType operationType, Priority priority, Deadline deadline)
        {
            this.Description = description;
            this.OperationType = operationType;
            this.Priority = priority;
            this.Deadline = deadline;
        }
    }
}