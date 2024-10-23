using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Mappers;

namespace DDDNetCore.Domain.Staffs;

public class StaffService
{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffRepository _repo;
        private StaffMapper _mapper;
        

        public StaffService(IUnitOfWork unitOfWork, IStaffRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            
        }
        
        public async Task<List<StaffDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            if (list == null || list.Count == 0)
            {
                throw new Exception("Users not found");
            }

            return list.Select(x => _mapper.toDto(x)).ToList();


        }
        public async Task<StaffDto> GetByIdAsync(StaffId id)
        {
            var cat = await this._repo.GetByIdAsync(id);
            
            if(cat == null)
                return null;

            return _mapper.toDto(cat);
        }

        public async Task<StaffDto> AddAsync(CreatingStaffDto dto)
        {
            List<AvailabilitySlot> slots = new List<AvailabilitySlot>();
            foreach (string slot in dto.slots)
            {
                slots.Add(new AvailabilitySlot(slot));
            }
            
            var staff = new Staff(new StaffId(dto.staffID), new LicenseNumber(dto.licenseNumber), new Specialization(dto.specialization), slots);

            await this._repo.AddAsync(staff);

            await this._unitOfWork.CommitAsync();

            return _mapper.toDto(staff);
        }

        public async Task<StaffDto> UpdateAsync(StaffDto dto)
        {
            var staff = await this._repo.GetByIdAsync(new StaffId(dto.StaffID)); 

            if (staff == null)
                return null;   

            // change all field
            staff.ChangeId(new StaffId(dto.StaffID));
            staff.ChangeLicenseNumber(new LicenseNumber(dto.LicenseNumber));
            staff.ChangeSpecialization(new Specialization(dto.Specialization));
            List<AvailabilitySlot> slots = new List<AvailabilitySlot>();
            foreach (string slot in dto.Slots)
            {
                slots.Add(new AvailabilitySlot(slot));
            }
            staff.ChangeAvailabilitySlot(slots);
            
            
            await this._unitOfWork.CommitAsync();

            return _mapper.toDto(staff);
        }

       

         public async Task<StaffDto> DeleteAsync(StaffId id)
        {
            var staff = await this._repo.GetByIdAsync(id); 

            if (staff == null)
                return null;   
            
            this._repo.Remove(staff);
            await this._unitOfWork.CommitAsync();

            return _mapper.toDto(staff);
        }
}