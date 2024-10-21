using System;
using System.Threading.Tasks;
using DDDNetCore.DTO;
using DDDNetCore.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace lapr5_2024_25_g5.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> RegisterPatient([FromBody] PatientDTO dto)
        {
            try
            {
                var patient = await _patientService.RegisterPatient(dto);
                return Ok(patient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var patients = await _patientService.GetPatients();
                return Ok(patients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }


//         [HttpPut("update/{id}")]
//         public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] UpdatePatientDTO dto)
//         {
//             try
//             {
//                 var updatedPatient = await _patientService.UpdatePatientAsync(id, dto);
//                 return Ok(updatedPatient);
//             }
//             catch (Exception e)
//             {
//                 return BadRequest(e.Message);
//             }
//         }
//
//         [HttpDelete("delete/{email}")]
//         public async Task<IActionResult> DeletePatient(string email)
//         {
//             try
//             {
//                 var result = await _patientService.DeletePatientByEmailAsync(email);
//                 if (result)
//                 {
//                     return Ok("Patient and user successfully deleted.");
//                 }
//
//                 return NotFound("Patient or user not found.");
//             }
//             catch (Exception e)
//             {
//                 return BadRequest(e.Message);
//             }
//         }
//     }
 }