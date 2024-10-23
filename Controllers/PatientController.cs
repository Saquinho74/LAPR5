using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Patient;
using DDDNetCore.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace lapr5_2024_25_g5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            return await _patientService.GetAllAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetGetById(Guid id)
        {
            var cat = await _patientService.GetByIdAsync(new PatientId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // POST: api/Operation
        [HttpPost]
        public async Task<ActionResult<PatientDto>> Create(PatientDto dto)
        {
            var cat = await _patientService.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = cat.PatientId }, cat);
        }



        // PUT: api/Operation/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PatientDto>> Update(Guid id, PatientDto dto)
        {
            if (id.ToString() != dto.PatientId)
            {
                return BadRequest();
            }

            try
            {
                var cat = await _patientService.UpdateAsync(dto);

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // Inactivate: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientDto>> SoftDelete(Guid id)
        {
            var cat = await _patientService.InactivateAsync(new PatientId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<PatientDto>> HardDelete(Guid id)
        {
            try
            {
                var cat = await _patientService.DeleteAsync(new PatientId(id));

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}