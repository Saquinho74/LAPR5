using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class EmergencyContact : IValueObject
{
    public string emergyContact { get; private set; }

    public EmergencyContact()
    {
    }

    public EmergencyContact(string dtoEmergencyContact)
    {
        this.emergyContact = dtoEmergencyContact;

    }
}