using DDDNetCore.Domain.Credential;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Credential
{
    public class CredentialRepository : BaseRepository<Domain.Credential.Credential, CredentialId>, ICredentialRepository
    {
    
        public CredentialRepository(DddSample1DbContext context):base(context.Credentials)
        {
           
        }


    }
}