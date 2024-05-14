using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Exams;

namespace SIG_VETERINARIA.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository examRepository;

        public ExamService(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }

        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDTO request)
        {
            return await this.examRepository.CreateExam(request);
        }

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
            return await this.examRepository.DeleteExam(request);

        }

        public async Task<ResultDto<ExamListResponseDTO>> GetExams(ExamListRequestDTO request)
        {
            return await this.examRepository.GetExams(request);
        }
    }
}
