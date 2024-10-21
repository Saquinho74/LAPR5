using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.SurgeryRoom
{
    public class CreatingSurgeryRoomDto
    {
        public AssignedEquipment AssignedEquipment { get; set; }
        
        public CurrentStatus CurrentStatus { get; set; }
        
        public Capacity Capacity { get; set; }
        
        public MaintenanceSlot MaintenanceSlot { get; set; }
        
        public Type Type { get; set; }
        
        public CreatingSurgeryRoomDto(AssignedEquipment assignedEquipment, CurrentStatus currentStatus, Capacity capacity, MaintenanceSlot maintenanceSlot, Type type )
        {
            this.AssignedEquipment = assignedEquipment;
            this.CurrentStatus = currentStatus;
            this.Capacity = capacity;
            this.MaintenanceSlot = maintenanceSlot;
            this.Type = type;

        }
    }
}