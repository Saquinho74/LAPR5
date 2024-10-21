using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDNetCore.Infraestructure.SurgeryRoom
{
    internal class SugeryRoomEntityTypeConfiguration : IEntityTypeConfiguration<Domain.SurgeryRoom.SurgeryRoom>
    {
        public void Configure(EntityTypeBuilder<Domain.SurgeryRoom.SurgeryRoom> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
        }
    }
}