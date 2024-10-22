using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Patient;

public class ContactInformation : IValueObject{
    
    public string contactInformation { get; private set; }
    
    public ContactInformation(string contactInformation)
    {
    this.contactInformation = contactInformation;
    }

    public ContactInformation()
    {
        
    }
}
