using System.Collections.Generic;
using System.Linq;
using DDDNetCore.Domain.Staffs;

namespace DDDNetCore.Mappers;

public class StaffMapper
{
    public Staff toDomain(StaffDto dto)
    {
        List<AvailabilitySlot> slots = new List<AvailabilitySlot>();
        foreach (string slot in dto.Slots)
        {
            slots.Add(new AvailabilitySlot(slot));
        }
        
        return new Staff(new StaffId(dto.StaffID),  new LicenseNumber(dto.LicenseNumber),new Specialization( dto.Specialization),slots);
    }

    public StaffDto toDto(Staff entity)
    {
        List<string> slots = new List<string>();
        foreach (var slot in entity.Slot)
        {
            slots.Add(slot.slot);
        }
        return new StaffDto{StaffID = entity.Id.ToString(), LicenseNumber = entity.LicenseNumber.ToString(), Specialization = entity.Specialization.ToString(), Slots = slots};
        
    }

    public Staff toDomain(CreatingStaffDto dto)
    {
        List<AvailabilitySlot> slots = new List<AvailabilitySlot>();
        foreach (string slot in dto.slots)
        {
            slots.Add(new AvailabilitySlot(slot));
        }
        return new Staff(new StaffId(dto.staffID), new LicenseNumber(dto.licenseNumber),new Specialization( dto.specialization), slots);
    }
    
    public List<StaffDto> toDtoList(List<Staff> list)
    {
        return list.Select(x => toDto(x)).ToList();
    }
}