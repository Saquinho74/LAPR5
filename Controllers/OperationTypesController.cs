using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.OperationType;
using DDDNetCore.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationTypesController : ControllerBase
    {
        private readonly OperationTypeService _service;

        public OperationTypesController(OperationTypeService service)
        {
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationTypeDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationTypeDto>> GetGetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new OperationTypeId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<OperationTypeDto>> Create(CreatingOperationTypeDto dto)
        {
            var cat = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = cat.Id }, cat);
        }

        
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationTypeDto>> Update(Guid id, OperationTypeDto dto)
        {
            if (id != dto.Id)
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
                return BadRequest(new {Message = ex.Message});
            }
        }

        // Inactivate: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationTypeDto>> SoftDelete(Guid id)
        {
            var cat = await _service.InactivateAsync(new OperationTypeId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }
        
        // DELETE: api/Categories/5
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<OperationTypeDto>> HardDelete(Guid id)
        {
            try
            {
                var cat = await _service.DeleteAsync(new OperationTypeId(id));

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
        
    } 
}