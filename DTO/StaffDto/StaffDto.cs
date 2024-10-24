﻿using System.Collections.Generic;

namespace DDDNetCore.DTO.StaffDto;

public class StaffDto
{
    public string StaffID { get; set; }
    public string LicenseNumber { get; set; }
    public string Specialization { get; set; }
    public List<string> Slots { get; set; }

    public string ToString()
    {
        return StaffID + " " + LicenseNumber + " " + Specialization + " " + Slots;
    }
}