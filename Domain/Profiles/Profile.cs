using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Profile
{
    public class Profile : IAggregateRoot
    {
        public PhoneNumber PhoneNumber { get; private set; }
        public OperationalTypeName OperationalTypeName { get; private set; }
        public bool Active { get; private set; }

        // Default constructor for Entity Framework or ORM (protected/private for encapsulation)
        private Profile()
        {
            this.Active = true; // Default to active when created
        }

        // Constructor that accepts required values
        public Profile(PhoneNumber phoneNumber, OperationalTypeName operationalTypeName)
        {
            this.PhoneNumber = phoneNumber;  // Assign the PhoneNumber Value Object
            this.OperationalTypeName = operationalTypeName;  // Assign the OperationalTypeName Value Object
            this.Active = true; // Default to active when created
        }

        // Optionally, you can have methods to modify the state
        public void Deactivate()
        {
            this.Active = false;
        }

        public void Activate()
        {
            this.Active = true;
        }

        // Additional behavior could be added, like updating phone number or operational type
        public void UpdatePhoneNumber(PhoneNumber newPhoneNumber)
        {
            this.PhoneNumber = newPhoneNumber;
        }

        public void UpdateOperationalTypeName(OperationalTypeName newOperationalTypeName)
        {
            this.OperationalTypeName = newOperationalTypeName;
        }
    }
}