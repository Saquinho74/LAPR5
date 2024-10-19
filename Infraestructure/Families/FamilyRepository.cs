using DDDNetCore.Domain.Families;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Families
{
    public class FamilyRepository : BaseRepository<Family, FamilyId>, IFamilyRepository
    {
      
        public FamilyRepository(DddSample1DbContext context):base(context.Families)
        {
            
        }

    }
}