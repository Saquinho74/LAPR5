using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Domain.Staff;
using DDDNetCore.Domain.Staffs;
using DDDNetCore.DTO.StaffDto;
using DDDNetCore.Infraestructure.Staff;

namespace DDDNetCore.Service
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffRepository _repo;


        public StaffService(IUnitOfWork unitOfWork, IStaffRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<StaffDto>> GetAllAsync()
        {
            var staffs = await _repo.GetAllAsync();
            var staffsDto = new List<StaffDto>();

            foreach (var staff in staffs)
            {
                staffsDto.Add(new StaffDto
                {
                    StaffID = staff.Id.Value,
                    LicenseNumber = staff.LicenseNumber.Value,
                    Specialization = staff.Specialization.Value,
                    Slots = staff.Slot.Select(slot => slot.ToString()).ToList() // Convert slots to string
                });
            }

            return staffsDto;
        }

        public async Task<StaffDto> GetByIdAsync(StaffId id)
        {
            var staff = await this._repo.GetByIdAsync(id);
            if (staff == null)
            {
                return null;
            }

            return new StaffDto
            {
                StaffID = staff.Id.Value,
                LicenseNumber = staff.LicenseNumber.Value,
                Specialization = staff.Specialization.Value,
                Slots = staff.Slot.Select(slot => slot.ToString()).ToList() // Convert slots to string
            };
        }

        public async Task<StaffDto> AddAsync(CreatingStaffDto dto)
        {
            List<AvailabilitySlot> slots = Staff.listToAvailabilitySlot(dto.slots);

            var staff = new Staff(
                StaffId.Create(dto.staffID),
                new LicenseNumber(dto.licenseNumber),
                new Specialization(dto.specialization),
                slots
            );

            await this._repo.AddAsync(staff);
            await this._unitOfWork.CommitAsync();

            return new StaffDto
            {
                StaffID = staff.Id.Value,
                LicenseNumber = staff.LicenseNumber.Value,
                Specialization = staff.Specialization.Value,
                Slots = slots.Select(slot => slot.ToString()).ToList() // Convert slots to string
            };
        }

        public async Task<StaffDto> UpdateAsync(StaffDto dto)
        {
            var staff = await this._repo.GetByIdAsync(StaffId.Create(dto.StaffID));
            if (staff == null)
                return null;

            // Change all fields
            staff.ChangeId(StaffId.Create(dto.StaffID));
            staff.ChangeLicenseNumber(new LicenseNumber(dto.LicenseNumber));
            staff.ChangeSpecialization(new Specialization(dto.Specialization));

            List<AvailabilitySlot>
                slots = dto.Slots.Select(slot => new AvailabilitySlot(slot))
                    .ToList(); // Convert DTO slots to AvailabilitySlot
            staff.ChangeAvailabilitySlot(slots);

            await this._unitOfWork.CommitAsync();

            return new StaffDto
            {
                StaffID = staff.Id.Value,
                LicenseNumber = staff.LicenseNumber.Value,
                Specialization = staff.Specialization.Value,
                Slots = slots.Select(slot => slot.ToString()).ToList() // Convert slots to string
            };
        }

        public async Task<StaffDto> DeleteAsync(string id)
        {
            var staff = await this._repo.GetByIdAsync(StaffId.Create(id));
            if (staff == null)
                return null;

            this._repo.Remove(staff);
            await this._unitOfWork.CommitAsync();

            return new StaffDto
            {
                StaffID = staff.Id.Value,
                LicenseNumber = staff.LicenseNumber.Value,
                Specialization = staff.Specialization.Value,
                Slots = staff.Slot.Select(slot => slot.ToString()).ToList() // Convert slots to string
            };
        }
    }
}

