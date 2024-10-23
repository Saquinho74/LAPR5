using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Staffs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly StaffService _service;
    
    
    public StaffController(StaffService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()
    {
        try
        {
            var staff = await _service.GetAllAsync();
            return Ok(staff);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<StaffDto>> GetById(string id)
    {
        var staff = await _service.GetByIdAsync(new StaffId(id));
        if (staff == null)
        {  
            return NotFound();
        }

        return staff;
    }

    [HttpPost]
    public async Task<ActionResult<StaffDto>> Create(CreatingStaffDto dto)
    {
        var staff = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = staff.StaffID }, staff);    
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<StaffDto>> Update([FromRoute] StaffId id, [FromBody] StaffDto dto)
    {
        if (id.ToString() != dto.StaffID)
        {
            return BadRequest();
        }

        try
        {
            var cat = await _service.UpdateAsync(dto);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }
        catch (Exception ex)
        {
            return BadRequest(new {Message = ex.Message});
        }
    }
    [HttpDelete("{id}/hard")]
    public async Task<ActionResult<StaffDto>> HardDelete(StaffId id)
    {
        try
        {
            var cat = await _service.DeleteAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }
        catch(Exception ex)
        {
            return BadRequest(new {Message = ex.Message});
        }
    }
}