using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Exams;

namespace SIG_VETERINARIA.Abstractions.IRepository
{
    public interface IExamRepository
    {
        public Task<ResultDto<ExamListResponseDTO>> GetExams(ExamListRequestDTO request);
        public Task<ResultDto<int>> CreateExam(ExamCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteExam(DeleteDto request);
    }
}
