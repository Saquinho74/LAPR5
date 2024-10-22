using System;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.SurgeryRoom
{
    public class SurgeryRoom : Entity<SurgeryRoomId>, IAggregateRoot
    {
        public AssignedEquipment AssignedEquipment { get; private set; }
        public CurrentStatus CurrentStatus { get; private set; }
        public Capacity Capacity { get; private set; }
        public MaintenanceSlot MaintenanceSlot { get; private set; }
        public Type Type { get; private set; }

        // Constructor to initialize the SurgeryRoom entity with required parameters
        public SurgeryRoom(
            AssignedEquipment assignedEquipment,
            CurrentStatus currentStatus,
            Capacity capacity,
            MaintenanceSlot maintenanceSlot,
            Type type)
        {
            this.Id = new SurgeryRoomId(Guid.NewGuid()); // Generate a new unique ID for SurgeryRoom
            this.AssignedEquipment = assignedEquipment ?? throw new ArgumentNullException(nameof(assignedEquipment)); // Ensure AssignedEquipment is not null
            this.CurrentStatus = currentStatus; // Ensure CurrentStatus is not null
            this.Capacity = capacity ?? throw new ArgumentNullException(nameof(capacity)); // Ensure Capacity is not null
            this.MaintenanceSlot = maintenanceSlot ?? throw new ArgumentNullException(nameof(maintenanceSlot)); // Ensure MaintenanceSlot is not null
            this.Type = type ?? throw new ArgumentNullException(nameof(type)); // Ensure Type is not null
        }

            // Construtor padrão
            public SurgeryRoom() 
            {
            }

       


        // Method to change the assigned equipment
        public void ChangeAssignedEquipment(AssignedEquipment assignedEquipment)
        {
            this.AssignedEquipment = assignedEquipment ?? throw new ArgumentNullException(nameof(assignedEquipment));
        }

        // Method to change the current status
        public void ChangeCurrentStatus(CurrentStatus currentStatus)
        {
            // We assume CurrentStatus is required, so we throw an exception if it's null
            if (currentStatus == null)
                throw new ArgumentNullException(nameof(currentStatus), "CurrentStatus cannot be null.");

            this.CurrentStatus = currentStatus; // Assign the new current status
        }

        // Method to change the capacity
        public void ChangeCapacity(Capacity capacity)
        {
            this.Capacity = capacity; // Capacity can be assigned as null based on your requirements
        }

        // Method to change the maintenance slot
        public void ChangeMaintenanceSlot(MaintenanceSlot maintenanceSlot)
        {
            this.MaintenanceSlot = maintenanceSlot; // MaintenanceSlot can be assigned as null based on your requirements
        }

        // Method to change the type of surgery room
        public void ChangeType(Type type)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type)); // Ensure Type is not null
        }
        
    }
}
