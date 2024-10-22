using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class AppointmentHistory : IValueObject
{
    public List<string> appointementHistory { get; private set; }
    
    public AppointmentHistory()
    {
    }

    public AppointmentHistory(List<string> dtoAppointmentHistory)
    {
        this.appointementHistory = dtoAppointmentHistory;
    }
    
}