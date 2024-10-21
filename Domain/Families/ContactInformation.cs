using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Families;

public class ContactInformation : IValueObject{
    
    public List<JSType.String> contactInformation { get; private set; }
    
    public ContactInformation()
    {
    this.contactInformation = contactInformation;
    }

    public void addContactInformation(JSType.String contactInformation)
    {
    this.contactInformation.Add(contactInformation);
    }
}
