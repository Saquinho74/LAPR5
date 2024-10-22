using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Patient;

public class EmergencyContact : IValueObject
{
    public string emergyContact { get; private set; }

    public EmergencyContact()
    {
    }

    public EmergencyContact(string emergencyContact)
    {
        this.emergyContact = emergencyContact;

    }
}