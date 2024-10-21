using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Credential; // Certifique-se de que o namespace está correto
using DDDNetCore.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialController : ControllerBase
    {
        private readonly CredentialService _service;

        public CredentialController(CredentialService service)
        {
            _service = service;
        }

        // GET: api/Credentials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CredentialDto>>> GetAll()
        {
            var credentials = await _service.GetAllAsync();
            return Ok(credentials);
        }

        // GET: api/Credentials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CredentialDto>> GetById(Guid id)
        {
            var credential = await _service.GetByIdAsync(new CredentialId(id));

            if (credential == null)
            {
                return NotFound();
            }

            return Ok(credential);
        }

        // POST: api/Credentials
        [HttpPost]
        public async Task<ActionResult<CredentialDto>> Create(CreatingCredentialDto dto)
        {
            var credential = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = credential.Id }, credential);
        }

        // PUT: api/Credentials/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CredentialDto>> Update(Guid id, CredentialDto dto)
        {
            if (id != id)
            {
                return BadRequest();
            }

            try
            {
                var updatedCredential = await _service.UpdateAsync(dto);

                if (updatedCredential == null)
                {
                    return NotFound();
                }

                return Ok(updatedCredential);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // SoftDelete: api/Credentials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CredentialDto>> SoftDelete(Guid id)
        {
            var credential = await _service.InactivateAsync(new CredentialId(id));

            if (credential == null)
            {
                return NotFound();
            }

            return Ok(credential);
        }

        // DELETE: api/Credentials/5/hard
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<CredentialDto>> HardDelete(Guid id)
        {
            try
            {
                var credential = await _service.DeleteAsync(new CredentialId(id));

                if (credential == null)
                {
                    return NotFound();
                }

                return Ok(credential);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
