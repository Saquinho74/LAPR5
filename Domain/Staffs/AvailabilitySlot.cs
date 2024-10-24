using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Staffs
{

    public class AvailabilitySlot : IValueObject
    {
        public string slot { get; set; }


        public AvailabilitySlot(string slot)
        {
            this.slot = slot;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            var other = (AvailabilitySlot)obj;
            return this.slot == other.slot;
        }
        public override int GetHashCode()
        {
            return this.slot.GetHashCode();
        }
        public override string ToString()
        {
            return slot;
        }

    }
}