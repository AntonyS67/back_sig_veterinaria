using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Exams;

namespace SIG_VETERINARIA.Abstractions.IApplication
{
    public interface IExamApplication
    {
        public Task<ResultDto<ExamListResponseDTO>> GetExams(ExamListRequestDTO request);
        public Task<ResultDto<int>> CreateExam(ExamCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteExam(DeleteDto request);
    }
}
