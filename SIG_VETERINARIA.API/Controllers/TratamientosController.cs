using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.API.Controllers
{
    [Route("api/tratamientos")]
    [ApiController]
    public class TratamientosController : ControllerBase
    {
        private readonly ITratamientoApplication _application;

        public TratamientosController(ITratamientoApplication application)
        {
            _application = application;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetAll([FromBody] TratamientosListRequestDTO request)
        {
            try
            {
                var res = await this._application.ListTratamientos(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Save([FromBody] TratamientosCreateRequestDTO request)
        {
            try
            {
                var res = await this._application.CreateTratamiento(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await this._application.DeleteTratamiento(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
