using DDDNetCore.Domain.Credential;
using DDDNetCore.Domain.Operation;

namespace DDDNetCore.Mappers;

public class ICredentialMapper
{
    public interface ICredentialTypeMapper : IMapper<Credential,CredentialDto,CreatingCredentialDto> {}

}