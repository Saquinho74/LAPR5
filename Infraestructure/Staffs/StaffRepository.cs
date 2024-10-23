using DDDNetCore.Domain.Staffs;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Staffs
{
    public class StaffRepository : BaseRepository<Staff, StaffId>, IStaffRepository
    {
        public StaffRepository(DddSample1DbContext context) : base(context.Staff)
        {

        }
    }
}