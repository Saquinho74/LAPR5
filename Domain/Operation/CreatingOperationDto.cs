namespace DDDNetCore.Domain.Operation
{
    public class CreatingOperationDto
    {
        public string Description { get; set; }


        public CreatingOperationDto(string description)
        {
            this.Description = description;
        }
    }
}