using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Credential
{
    public interface ICredentialRepository: IRepository<Credential, CredentialId>
    {
    }
}