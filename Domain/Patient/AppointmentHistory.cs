using System.Collections.Generic;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Patient;

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