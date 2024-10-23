using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Staff;
using DDDNetCore.DTO.StaffDto;

namespace DDDNetCore.Service;

public interface IStaffService
{
    Task<List<StaffDto>> GetAllAsync();
    Task<StaffDto> GetByIdAsync(StaffId id);
    Task<StaffDto> AddAsync(CreatingStaffDto dto);
    Task<StaffDto> UpdateAsync(StaffDto dto);
    Task<StaffDto> DeleteAsync(string id);
    
}