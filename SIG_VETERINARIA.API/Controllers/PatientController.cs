using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Patients;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientApplication _patientApplication;

        public PatientController(IPatientApplication patientApplication)
        {
            _patientApplication = patientApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetPatients([FromBody] PatientListRequestDTO request)
        {
            try
            {
                var res = await _patientApplication.GetPatients(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreatePatient([FromForm] PatientCreateRequestDTO request)
        {
            try
            {
                var res = await _patientApplication.CreatePatient(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeletePatient([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await _patientApplication.DeletePatient(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
