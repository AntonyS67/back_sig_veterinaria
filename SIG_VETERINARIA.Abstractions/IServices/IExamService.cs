using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Exams;

namespace SIG_VETERINARIA.Abstractions.IServices
{
    public interface IExamService
    {
        public Task<ResultDto<ExamListResponseDTO>> GetExams(ExamListRequestDTO request);
        public Task<ResultDto<int>> CreateExam(ExamCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteExam(DeleteDto request);
    }
}
