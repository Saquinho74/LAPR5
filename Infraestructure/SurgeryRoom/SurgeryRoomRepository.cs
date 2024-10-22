using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.SurgeryRoom;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.SurgeryRoom
{
    public class SurgeryRoomRepository : BaseRepository<Domain.SurgeryRoom.SurgeryRoom, SurgeryRoomId>, ISurgeryRoomRepository
    {
    
        public SurgeryRoomRepository(DddSample1DbContext context):base(context.SurgeryRooms)
        {
           
        }


    }
}