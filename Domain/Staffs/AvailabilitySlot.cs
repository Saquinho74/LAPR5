using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Staff;

public class AvailabilitySlot : IValueObject
{
    public string slot { get; set; }
        
        
    public AvailabilitySlot(string slot)
    {
        this.slot = slot;
    }
}