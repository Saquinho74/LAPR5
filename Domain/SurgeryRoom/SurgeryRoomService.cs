using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<SurgeryRoomDto> CreateAsync(SurgeryRoomDto creatingDto)
        {
            // Mapeia DTO para entidade SurgeryRoom
            var surgeryRoom = new SurgeryRoom(
                new AssignedEquipment(creatingDto.AssignedEquipment),
                Enum.Parse<CurrentStatus>(creatingDto.CurrentStatus, true), // Tratamento para o enum Status
                new Capacity(int.Parse(creatingDto.Capacity)),
                ParseMaintenanceSlot(creatingDto
                    .MaintenanceSlot), // Converte a string MaintenanceSlot para o Value Object
                new Type(creatingDto.Type)
            );

            await _repo.AddAsync(surgeryRoom);
            await _unitOfWork.CommitAsync();

            return SurgeryRoomMapper.toDTO(surgeryRoom);
        }

        // Método auxiliar para processar o campo MaintenanceSlot
        private MaintenanceSlot ParseMaintenanceSlot(string maintenanceSlotString)
        {
            // Supondo que o campo MaintenanceSlot tenha o formato "yyyy-MM-dd HH:mm:ss - HH:mm:ss"
            var slotParts = maintenanceSlotString.Split(" - ");

            if (slotParts.Length != 2)
                throw new ArgumentException("MaintenanceSlot deve ter o formato 'yyyy-MM-dd HH:mm:ss - HH:mm:ss'.");

            var datePart = slotParts[0].Substring(0, 10); // Extrai a parte da data (yyyy-MM-dd)
            var startTimePart = slotParts[0].Substring(11); // Extrai o horário de início (HH:mm:ss)
            var endTimePart = slotParts[1]; // Extrai o horário de término (HH:mm:ss)

            var date = DateTime.ParseExact(datePart, "yyyy-MM-dd", null); // Converte a data
            var startTime = TimeSpan.Parse(startTimePart); // Converte o horário de início
            var endTime = TimeSpan.Parse(endTimePart); // Converte o horário de término

            return new MaintenanceSlot(date, startTime, endTime);
        }

        // Método para atualizar uma sala de cirurgia existente
        public async Task<SurgeryRoomDto> UpdateAsync(SurgeryRoomId id, SurgeryRoomDto updatingDto)
        {
            var surgeryRoom = await _repo.GetByIdAsync(id);

            if (surgeryRoom == null)
                return null;

            // Atualiza a sala de cirurgia com novos valores
            surgeryRoom.ChangeAssignedEquipment(new AssignedEquipment(updatingDto.AssignedEquipment));
            surgeryRoom.ChangeCurrentStatus(Enum.Parse<CurrentStatus>(updatingDto.CurrentStatus, true));
            surgeryRoom.ChangeCapacity(new Capacity(int.Parse(updatingDto.Capacity)));
            surgeryRoom.ChangeMaintenanceSlot(ParseMaintenanceSlot(updatingDto.MaintenanceSlot));
            surgeryRoom.ChangeType(new Type(updatingDto.Type));

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
    }
}
