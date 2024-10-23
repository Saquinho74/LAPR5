using System;
using System.Collections.Generic;

namespace DDDNetCore.DTO.StaffDto;

public class CreatingStaffDto
{
    public string staffID { get; set; }
    public string licenseNumber { get; set; }
    public string specialization { get; set; }
    public List<string> slots { get; set; }
    
    public CreatingStaffDto(string staffId, string licenseNumber, string specialization, List<String> slots)
    {
        staffID = staffId;
        this.licenseNumber = licenseNumber;
        this.specialization = specialization;
        this.slots = slots;
    }
}