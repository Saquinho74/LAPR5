using System;
using System.Collections.Generic;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.SurgeryRoom;
using Type = DDDNetCore.Domain.SurgeryRoom.Type;

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
    
    // Método para mapear de DTO para Entidade
    public static SurgeryRoom toEntity(SurgeryRoomDto dto)
    {
        // Lógica de conversão do DTO para SurgeryRoom
        return new SurgeryRoom(
            new AssignedEquipment(dto.AssignedEquipment),
            Enum.Parse<CurrentStatus>(dto.CurrentStatus, true), // Tratamento para o enum Status
            new Capacity(int.Parse(dto.Capacity)),
            ParseMaintenanceSlot(dto.MaintenanceSlot), // Converte a string MaintenanceSlot para o Value Object
            new Type(dto.Type)
        );
    }

    // Método auxiliar para processar o campo MaintenanceSlot
    public static MaintenanceSlot ParseMaintenanceSlot(string maintenanceSlotString)
    {
        // Supondo que o campo MaintenanceSlot tenha o formato "yyyy-MM-dd HH:mm:ss - HH:mm:ss"
        var slotParts = maintenanceSlotString.Split(" - ");

        if (slotParts.Length != 2)
            throw new ArgumentException("MaintenanceSlot deve ter o formato 'yyyy-MM-dd HH:mm:ss - HH:mm:ss'.");

        var datePart = slotParts[0].Substring(0, 10);           // Extrai a parte da data (yyyy-MM-dd)
        var startTimePart = slotParts[0].Substring(11);         // Extrai o horário de início (HH:mm:ss)
        var endTimePart = slotParts[1];                         // Extrai o horário de término (HH:mm:ss)

        var date = DateTime.ParseExact(datePart, "yyyy-MM-dd", null);  // Converte a data
        var startTime = TimeSpan.Parse(startTimePart);                 // Converte o horário de início
        var endTime = TimeSpan.Parse(endTimePart);                     // Converte o horário de término

        return new MaintenanceSlot(date, startTime, endTime);
    }
}