using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Categories;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            this.categoryApplication = categoryApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetAll([FromBody] CategoriesListRequestDTO request)
        {
            try
            {

                var res = await categoryApplication.GetCategories(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] CategoriesCreateRequestDTO request)
        {
            try
            {
                var res = await categoryApplication.CreateCategory(request);
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
                var res = await categoryApplication.DeleteCategory(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
