using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Mappers;

namespace DDDNetCore.Domain.SurgeryRoom
{
    public class SurgeryRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISurgeryRoomRepository _repo;

        public SurgeryRoomService(IUnitOfWork unitOfWork, ISurgeryRoomRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        // Método para obter todas as salas de cirurgia
        public async Task<List<SurgeryRoomDto>> GetAllAsync()
        {
            var surgeryRooms = await _repo.GetAllAsync();

            // Conversão das salas de cirurgia em DTOs
            var listDto = SurgeryRoomMapper.toDTOList(surgeryRooms);

            return listDto;
        }

        // Método para obter uma sala de cirurgia por ID
        public async Task<SurgeryRoomDto> GetByIdAsync(SurgeryRoomId id)
        {
            var surgeryRoom = await _repo.GetByIdAsync(id);

            if (surgeryRoom == null)
                return null;

            var dtoReturn = SurgeryRoomMapper.toDTO(surgeryRoom);

            return dtoReturn;
        }

        // Método para criar uma nova sala de cirurgia
        public async Task<SurgeryRoomDto> CreateAsync(CreatingSurgeryRoomDto creatingDto)
        {
            // Mapear DTO para a entidade
            var surgeryRoom = new SurgeryRoom(
                assignedEquipment: creatingDto.AssignedEquipment,
                currentStatus: creatingDto.CurrentStatus,
                capacity: creatingDto.Capacity,
                maintenanceSlot: creatingDto.MaintenanceSlot,
                type: creatingDto.Type
            );

            await _repo.AddAsync(surgeryRoom);
            await _unitOfWork.CommitAsync();

            return SurgeryRoomMapper.toDTO(surgeryRoom);
        }

// Método para atualizar uma sala de cirurgia existente
        public async Task<SurgeryRoomDto> UpdateAsync(SurgeryRoomId id, CreatingSurgeryRoomDto updatingDto)
        {
            var surgeryRoom = await _repo.GetByIdAsync(id);

            if (surgeryRoom == null)
                return null;

            // Atualiza a sala de cirurgia com novos valores
            surgeryRoom.ChangeAssignedEquipment(updatingDto.AssignedEquipment);
            surgeryRoom.ChangeCurrentStatus(updatingDto.CurrentStatus);
            surgeryRoom.ChangeCapacity(updatingDto.Capacity);
            surgeryRoom.ChangeMaintenanceSlot(updatingDto.MaintenanceSlot);
            surgeryRoom.ChangeType(updatingDto.Type);

            await _unitOfWork.CommitAsync();

            return SurgeryRoomMapper.toDTO(surgeryRoom);
        }


        // Método para remover uma sala de cirurgia
        public async Task<bool> DeleteAsync(SurgeryRoomId id)
        {
            var surgeryRoom = await _repo.GetByIdAsync(id);

            if (surgeryRoom == null)
                return false;

            _repo.Remove(surgeryRoom);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<object> AddAsync(CreatingSurgeryRoomDto dto)
        {

            // Mapeando o DTO para a entidade, convertendo CurrentStatus corretamente
            var surgeryRoom = new SurgeryRoom(
                assignedEquipment: dto.AssignedEquipment,
                currentStatus: dto.CurrentStatus, // Passa o enum diretamente
                capacity: new Capacity(dto.Capacity.Value), // Supondo que Capacity é um Value Object
                maintenanceSlot: new MaintenanceSlot(dto.MaintenanceSlot.Date, dto.MaintenanceSlot.StartTime,
                    dto.MaintenanceSlot.EndTime), // Mapeando MaintenanceSlot
                type: new Type(dto.Type.Value) // Supondo que Type é um Value Object
            );

            await _repo.AddAsync(surgeryRoom);
            await _unitOfWork.CommitAsync();

            return SurgeryRoomMapper.toDTO(surgeryRoom);
        }
    }
    
}
