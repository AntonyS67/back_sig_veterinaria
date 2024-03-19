using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Species;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("api/species")]
    public class SpecieController : ControllerBase
    {
        private ISpecieApplication _specieApplication;

        public SpecieController(ISpecieApplication specieApplication)
        {
            _specieApplication = specieApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetAll([FromBody] SpecieListRequestDto request)
        {
            try
            {
                var res = await _specieApplication.GetAll(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] SpecieCreateRequestDto request)
        {
            try
            {
                var res = await _specieApplication.CreateSpecie(request);
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
                var res = await _specieApplication.DeleteSpecie(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
