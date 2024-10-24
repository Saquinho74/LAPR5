﻿using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.SurgeryRoom
{
    public class MaintenanceSlot : IValueObject
    {
        public DateTime Date { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

        // Constructor to create a valid MaintenanceSlot object
        public MaintenanceSlot(DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            if (date.Date < DateTime.Today)
                throw new BusinessRuleValidationException("The date cannot be in the past.");

            if (startTime >= endTime)
                throw new BusinessRuleValidationException("Start time must be before end time.");

            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }

        // Override equality checks to treat the maintenance slot as a value object
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (MaintenanceSlot)obj;
            return Date == other.Date && StartTime == other.StartTime && EndTime == other.EndTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Date, StartTime, EndTime);
        }

        // Override the ToString method for easy display
        public override string ToString()
        {
            return $"{Date.ToShortDateString()} from {StartTime} to {EndTime}";
        }
    }
    
    
    
    
}