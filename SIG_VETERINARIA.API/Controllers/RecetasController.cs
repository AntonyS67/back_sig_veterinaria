using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Recetas;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("/api/recetas")]
    public class RecetasController : ControllerBase
    {
        private readonly IRecetasApplication _recetasApplication;

        public RecetasController(IRecetasApplication recetasApplication)
        {
            _recetasApplication = recetasApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetAll([FromBody] RecetasListRequestDTO request)
        {
            try
            {
                var res = await this._recetasApplication.GetAllRecetas(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] RecetasCreateRequestDTO request)
        {
            try
            {
                var res = await this._recetasApplication.CreateReceta(request);
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
                var res = await this._recetasApplication.DeleteReceta(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
