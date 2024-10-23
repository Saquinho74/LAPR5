using System.Collections.Generic;
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
                List<string> slots = new List<string>();
                slots.Add(staff.Slot.ToString());
                staffsDto.Add(new StaffDto
                {
                    StaffID = staff.Id.Value,
                    LicenseNumber = staff.LicenseNumber.Value,
                    Specialization = staff.Specialization.Value,
                    Slots = slots
                });
            }

            return staffsDto;
        }

        public async Task<StaffDto> GetByIdAsync(StaffId id)
        {
            var cat = await this._repo.GetByIdAsync(id);
            if (cat == null)
            {
                return null;
            }

            List<string> slots = new List<string>();
            slots.Add(cat.Slot.ToString());
            return new StaffDto
            {
                StaffID = cat.Id.Value, LicenseNumber = cat.LicenseNumber.Value,
                Specialization = cat.Specialization.Value,
                Slots = slots
            };
        }

        public async Task<StaffDto> AddAsync(CreatingStaffDto dto)
        {
            List<AvailabilitySlot> slots = Staff.listToAvailabilitySlot(dto.slots);
            

            var staff = new Staff(StaffId.Create(dto.staffID), new LicenseNumber(dto.licenseNumber),
                new Specialization(dto.specialization), slots);
            await this._repo.AddAsync(staff);
            await this._unitOfWork.CommitAsync();
            return new StaffDto
            {
                StaffID = staff.Id.Value,
                LicenseNumber = staff.LicenseNumber.Value,
                Slots = dto.slots,
                Specialization = dto.specialization
            };
        }

        public async Task<StaffDto> UpdateAsync(StaffDto dto)
        {
            var staff = await this._repo.GetByIdAsync(StaffId.Create(dto.StaffID));
            if (staff == null)
                return null;
            // change all field
            staff.ChangeId(StaffId.Create(dto.StaffID));
            staff.ChangeLicenseNumber(new LicenseNumber(dto.LicenseNumber));
            staff.ChangeSpecialization(new Specialization(dto.Specialization));
            List<AvailabilitySlot> slots = new List<AvailabilitySlot>();
            foreach (string slot in dto.Slots)
            {
                slots.Add(new AvailabilitySlot(slot));
            }

            staff.ChangeAvailabilitySlot(slots);


            await this._unitOfWork.CommitAsync();
            return new StaffDto
            {
                StaffID = staff.Id.Value,
                LicenseNumber = staff.LicenseNumber.Value,
                Specialization = staff.Specialization.Value,
                Slots = dto.Slots
            };
        }

        public async Task<StaffDto> DeleteAsync(string id)
        {
            var staff = await this._repo.GetByIdAsync(StaffId.Create(id));
            if (staff == null)
                return null;

            this._repo.Remove(staff);
            await this._unitOfWork.CommitAsync();
            List<string> slots = Staff.listFromAvailabilitySlot(staff.Slot);
            return new StaffDto
            {
                StaffID = staff.Id.Value,
                LicenseNumber = staff.LicenseNumber.Value,
                Specialization = staff.Specialization.Value
            };
        }
    }
}