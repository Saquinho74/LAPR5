using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDNetCore.Infraestructure.Credential
{
    internal class CredentialEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Credential.Credential>
    {
        public void Configure(EntityTypeBuilder<Domain.Credential.Credential> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
            //builder.ToTable("Credential", SchemaNames.DDDSample1);
            builder.HasKey(b => b.Id);
            
            builder.OwnsOne(b => b.Email);
            builder.OwnsOne(b => b.Username);
        }
    }
}