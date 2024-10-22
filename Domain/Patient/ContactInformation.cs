using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class ContactInformation : IValueObject{
    
    public string contactInformation { get; private set; }
    
    public ContactInformation()
    {
    this.contactInformation = contactInformation;
    }

    public ContactInformation(string dtoContactInformation)
    {
    this.contactInformation = contactInformation;
    }
}
