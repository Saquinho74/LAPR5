using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Staffs
{
    public class AvailabilitySlot : IValueObject
    {
        public string slot { get; set; }
        
        

        public AvailabilitySlot(String slot)
        {
            this.slot = slot;
        }
    }
}