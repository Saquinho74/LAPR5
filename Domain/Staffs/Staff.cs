using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Staff;

public class Staff : Entity<StaffId>, IAggregateRoot
{
    public LicenseNumber LicenseNumber { get; private set; }
    public Specialization Specialization { get; private set; }
    public List<AvailabilitySlot> Slot { get; private set; }

    private Staff()
    {
        Slot = new List<AvailabilitySlot>();
    }

    public Staff(StaffId staffId, LicenseNumber licenseNumber, Specialization specialization,
        List<AvailabilitySlot> slot)
    {
        this.Id = staffId;
        LicenseNumber = licenseNumber;
        Specialization = specialization;
        Slot = slot;
        Slot = slot ?? new List<AvailabilitySlot>();
    }

    public void ChangeId(StaffId id)
    {
        this.Id = id;
    }

    public void ChangeLicenseNumber(LicenseNumber value)
    {
        this.LicenseNumber = value;
    }

    public void ChangeSpecialization(Specialization value)
    {
        this.Specialization = value;
    }

    public void ChangeAvailabilitySlot(List<AvailabilitySlot> value)
    {
        this.Slot = value;
    }

    public static List<string> listFromAvailabilitySlot(List<AvailabilitySlot> slots)
    {
        List<string> list = new List<string>();
        foreach (var slot in slots)
        {
            list.Add(slot.slot);
        }

        return list;
    }
    public static List<AvailabilitySlot> listToAvailabilitySlot(List<string> slots)
    {
        List<AvailabilitySlot> list = new List<AvailabilitySlot>();
        foreach (var slot in slots)
        {
            list.Add(new AvailabilitySlot(slot));
        }

        return list;
    }
}