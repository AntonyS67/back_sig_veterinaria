using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Exams;

namespace SIG_VETERINARIA.Application.Exams
{
    public class ExamApplication : IExamApplication
    {
        private readonly IExamService examService;

        public ExamApplication(IExamService examService)
        {
            this.examService = examService;
        }

        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDTO request)
        {
            return await this.examService.CreateExam(request);
        }

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
            return await this.examService.DeleteExam(request);
        }

        public async Task<ResultDto<ExamListResponseDTO>> GetExams(ExamListRequestDTO request)
        {
            return await this.examService.GetExams(request);
        }
    }
}
