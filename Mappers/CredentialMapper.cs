using System.Collections.Generic;
using DDDNetCore.Domain.Credential;

namespace DDDNetCore.Mappers;

public class CredentialMapper
{
    public static CredentialDto toDTO(Credential credential)
    {
        return new CredentialDto
        { 
            Id = credential.Id.AsGuid().ToString(),        
            Email = credential.Email.Value,           
            Username = credential.Username.Value,
            UserStatus = credential.UserStatus.ToString()
        };
    }
    
    public static List<CredentialDto> toDTOList(List<Credential> credential)
    {
        return credential.ConvertAll(credential => new CredentialDto
        {
            Id = credential.Id.AsGuid().ToString(),
            Email = credential.Email.Value,
            Username = credential.Username.Value,
            UserStatus = credential.UserStatus.ToString()
        });
    }
}