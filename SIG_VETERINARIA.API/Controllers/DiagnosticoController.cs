using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("api/diagnosticos")]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoApplication _diagnosticoApplication;

        public DiagnosticoController(IDiagnosticoApplication diagnosticoApplication)
        {
            _diagnosticoApplication = diagnosticoApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetDiagnosticos([FromBody] DiagnosticoListRequestDTO request)
        {
            try
            {
                var res = await this._diagnosticoApplication.GetDiagnosticos(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateDiagnostico([FromBody] DiagnosticoCreateRequestDTO request)
        {
            try
            {
                var res = await this._diagnosticoApplication.CreateDiagnostico(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteDiagnostico([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await this._diagnosticoApplication.DeleteDiagnostico(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
