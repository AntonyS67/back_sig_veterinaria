using Microsoft.AspNetCore.Mvc;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Exams;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("api/exams")]
    public class ExamController : ControllerBase
    {
        private readonly IExamApplication examApplication;

        public ExamController(IExamApplication examApplication)
        {
            this.examApplication = examApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetExams([FromBody] ExamListRequestDTO request)
        {
            try
            {
                var res = await this.examApplication.GetExams(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateExam([FromBody] ExamCreateRequestDTO request)
        {
            try
            {
                var res = await this.examApplication.CreateExam(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteExam([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await this.examApplication.DeleteExam(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
