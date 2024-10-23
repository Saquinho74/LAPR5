using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class AppointmentHistory : IValueObject
{
    public String appointementHistory { get; private set; }
    
    public AppointmentHistory()
    {
    }

    public AppointmentHistory(String dtoAppointmentHistory)
    {
        this.appointementHistory = dtoAppointmentHistory;
    }
    
}