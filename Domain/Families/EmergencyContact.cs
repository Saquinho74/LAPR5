using System;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class EmergencyContact : IValueObject
{
    public Double emergyContact { get; private set; }

    public EmergencyContact()
    {
        this.emergyContact = emergyContact;
    }

    public void addEmergencyContact(Double emergyContact)
    {
        this.emergyContact = emergyContact;
    }
}