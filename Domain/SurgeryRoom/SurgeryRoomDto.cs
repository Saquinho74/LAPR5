namespace DDDNetCore.Domain.SurgeryRoom
{
    public class SurgeryRoomDto
    {
        public string Id { get; set; }

        public string AssignedEquipment { get; set; }
        
        public string CurrentStatus { get; set; }
        
        public string Capacity { get; set; }
        
        public string MaintenanceSlot { get; set; }
        
        public string Type { get; set; }
        
    }
}