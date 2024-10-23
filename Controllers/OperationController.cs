using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly OperationService _service;

        public OperationController(OperationService service)
        {
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDto>> GetGetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new OperationId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // POST: api/Operation
        [HttpPost]
        public async Task<ActionResult<OperationDto>> Create(OperationDto dto)
        {
            var cat = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = cat.Id }, cat);
        }

        
        // PUT: api/Operation/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationDto>> Update(Guid id, OperationDto dto)
        {
            if (id.ToString() != dto.Id)
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
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message});
            }
        }

        // Inactivate: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationDto>> SoftDelete(Guid id)
        {
            var cat = await _service.InactivateAsync(new OperationId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }
        
        // DELETE: api/Categories/5
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<OperationDto>> HardDelete(Guid id)
        {
            try
            {
                var cat = await _service.DeleteAsync(new OperationId(id));

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new { ex.Message});
            }
        }
    }
}