using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Breeds;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.API.Controllers
{

    [ApiController]
    [Route("/api/breeds")]
    public class BreedController : ControllerBase
    {
        private IBreedApplication _breedApplication;

        public BreedController(IBreedApplication breedApplication)
        {
            _breedApplication = breedApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetBreeds(BreedListRequestDTO request)
        {
            try
            {
                var result = await this._breedApplication.GetBreeds(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateBreed([FromBody] BreedCreateRequestDTO request)
        {
            try
            {
                var result = await this._breedApplication.CreateBreed(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteBreed([FromQuery] DeleteDto request)
        {
            try
            {
                var result = await this._breedApplication.DeleteBreed(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
