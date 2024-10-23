using DDDNetCore.Domain.Staff;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Staff;

public class StaffRepository : BaseRepository<Domain.Staff.Staff, StaffId>, IStaffRepository
{
    public StaffRepository(DddSample1DbContext context) : base(context.Staff)
    {
    }
}