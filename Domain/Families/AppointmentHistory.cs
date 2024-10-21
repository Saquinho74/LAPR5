using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class AppointmentHistory : IValueObject
{
    public List<JSType.String> appointementHistory { get; private set; }
    
    public AppointmentHistory()
    {
        this.appointementHistory = appointementHistory;
    }

    public void addAppointmentHistory(JSType.String appointementHistory)
    {
        this.appointementHistory.Add(appointementHistory);
    }
}