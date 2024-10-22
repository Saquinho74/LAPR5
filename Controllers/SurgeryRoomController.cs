using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Domain.SurgeryRoom;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeryRoomController : ControllerBase
    {
        private readonly SurgeryRoomService _service;

        public SurgeryRoomController(SurgeryRoomService service)
        {
            _service = service;
        }

        // GET: api/SurgeryRoom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurgeryRoomDto>>> GetAll()
        {
            var surgeryRooms = await _service.GetAllAsync();
            return Ok(surgeryRooms);
        }

        // GET: api/SurgeryRoom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurgeryRoomDto>> GetById(Guid id)
        {
            var surgeryRoom = await _service.GetByIdAsync(new SurgeryRoomId(id));

            if (surgeryRoom == null)
            {
                return NotFound();
            }

            return Ok(surgeryRoom);
        }

        // POST: api/SurgeryRoom
        [HttpPost]
        public async Task<ActionResult<SurgeryRoomDto>> Create(CreatingSurgeryRoomDto dto)
        {
            var surgeryRoom = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = surgeryRoom }, surgeryRoom); // está mal REVER OS CONTROLLERS
        }

        // PUT: api/SurgeryRoom/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SurgeryRoomDto>> Update(Guid id, CreatingSurgeryRoomDto dto)
        {
            if (id != id) // Supondo que o DTO tem um Id (ou modifique conforme a estrutura do DTO)
            {
                return BadRequest("IDs do recurso e do DTO não correspondem.");
            }

            try
            {
                var updatedSurgeryRoom = await _service.UpdateAsync(new SurgeryRoomId(id), dto);

                if (updatedSurgeryRoom == null)
                {
                    return NotFound();
                }

                return Ok(updatedSurgeryRoom);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        

        // DELETE: api/SurgeryRoom/5/hard
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<SurgeryRoomDto>> HardDelete(Guid id)
        {
            try
            {
                var deletedSurgeryRoom = await _service.DeleteAsync(new SurgeryRoomId(id));

                if (deletedSurgeryRoom == null)
                {
                    return NotFound();
                }

                return Ok(deletedSurgeryRoom);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
