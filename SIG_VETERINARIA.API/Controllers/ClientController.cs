using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Clients;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplication _clientApplication;

        public ClientController(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetClients([FromBody] ClientListRequestDTO request)
        {
            try
            {
                var res = await _clientApplication.GetClients(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateClient([FromForm] ClientCreateRequestDTO request)
        {
            try
            {
                var res = await _clientApplication.CreateClient(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteCliente([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await _clientApplication.DeleteClient(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
