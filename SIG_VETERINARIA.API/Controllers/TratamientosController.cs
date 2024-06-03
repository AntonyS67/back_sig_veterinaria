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
        private readonly IProductsTratamientoApplication _productsTratamientoApplication;

        public TratamientosController(ITratamientoApplication application, IProductsTratamientoApplication productsTratamientoApplication)
        {
            _application = application;
            _productsTratamientoApplication = productsTratamientoApplication;
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
                //eliminar los productos del tratamiento
                await this._productsTratamientoApplication.DeleteProductTratamiento(res.Item);
                // se obtiene el id del tratamiento
                request.products.ForEach(item =>
                {
                    item.tratamiento_id = res.Item;
                });

                await this._productsTratamientoApplication.CreateProductTratamiento(request.products);
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

        [HttpPost]
        [Route("products/list")]
        public async Task<ActionResult> ListProducts([FromBody] ProductsTratamientoListRequestDTO request)
        {
            try
            {
                var res = await this._productsTratamientoApplication.GetProductsTratamiento(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("detail")]
        public async Task<ActionResult> DetailTratamiento([FromBody] ProductsTratamientoListRequestDTO request)
        {
            try
            {
                var res = await this._application.GetDetailTratamiento(request.tratamiento_id);
                var products = await this._productsTratamientoApplication.GetProductsTratamiento(request);

                return Ok(new { res, products });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
