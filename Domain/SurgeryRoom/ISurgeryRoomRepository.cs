using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.SurgeryRoom
{
    public interface ISurgeryRoomRepository: IRepository<SurgeryRoom, SurgeryRoomId>
    {
    }
}