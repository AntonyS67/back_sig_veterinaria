using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Consults;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("api/consults")]
    public class ConsultController : ControllerBase
    {
        private readonly IConsultApplication consultApplication;

        public ConsultController(IConsultApplication consultApplication)
        {
            this.consultApplication = consultApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetConsults([FromBody] ConsultListRequestDTO request)
        {
            try
            {
                var res = await this.consultApplication.GetConsults(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateConsult([FromBody] ConsultCreateRequestDTO request)
        {
            try
            {
                var res = await this.consultApplication.CreateConsult(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteConsult([FromQuery] DeleteDto request)
        {
            try
            {

                var res = await this.consultApplication.DeleteConsult(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
