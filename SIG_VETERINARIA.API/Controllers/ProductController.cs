using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Products;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication productApplication;

        public ProductController(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetAll([FromBody] ProductListRequestDTO request)
        {
            try
            {
                var res = await this.productApplication.GetProducts(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromForm] ProductCreateRequestDTO request)
        {
            try
            {
                var res = await this.productApplication.CreateProduct(request);
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
                var res = await this.productApplication.DeleteProduct(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
