using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDDNetCore.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDNetCore.Domain.Staffs
{
    public class Staff : Entity<StaffId>, IAggregateRoot {
        
        [Required]
        public LicenseNumber LicenseNumber { get; private set; }
        
        [Required]
        public Specialization Specialization { get; private set; }
        public List<AvailabilitySlot> Slot { get; private set; }
        
        public Staff (StaffId staffId, LicenseNumber licenseNumber, Specialization specialization, List<AvailabilitySlot> slot)
        {
            this.Id = staffId;
            LicenseNumber = licenseNumber;
            Specialization = specialization;
            Slot = slot;
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
        
    }
}