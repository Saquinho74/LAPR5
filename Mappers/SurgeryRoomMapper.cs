using System.Collections.Generic;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.SurgeryRoom;

namespace DDDNetCore.Mappers;

public class SurgeryRoomMapper
{
    public static SurgeryRoomDto toDTO (SurgeryRoom surgeryRoom)
    {
        return new SurgeryRoomDto
        { 
            Id = surgeryRoom.Id.AsGuid().ToString(),
            AssignedEquipment = surgeryRoom.AssignedEquipment.Value,
            CurrentStatus = surgeryRoom.CurrentStatus.ToString(),
            Capacity = surgeryRoom.Capacity.Value.ToString(),
            MaintenanceSlot = surgeryRoom.MaintenanceSlot.ToString(),
            Type = surgeryRoom.Type.ToString(),
        };
    }
    
    public static List<SurgeryRoomDto> toDTOList (List<SurgeryRoom> surgeryRoom)
    {
        return surgeryRoom.ConvertAll(surgeryRoom => new SurgeryRoomDto
        {
            Id = surgeryRoom.Id.AsGuid().ToString(),
            AssignedEquipment = surgeryRoom.AssignedEquipment.Value,
            CurrentStatus = surgeryRoom.CurrentStatus.ToString(),
            Capacity = surgeryRoom.Capacity.Value.ToString(),
            MaintenanceSlot = surgeryRoom.MaintenanceSlot.ToString(),
            Type = surgeryRoom.Type.ToString(),
        });
    }
}