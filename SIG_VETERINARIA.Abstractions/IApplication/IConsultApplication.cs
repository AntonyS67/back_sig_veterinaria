using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Consults;

namespace SIG_VETERINARIA.Abstractions.IApplication
{
    public interface IConsultApplication
    {
        public Task<ResultDto<ConsultListResponseDTO>> GetConsults(ConsultListRequestDTO request);
        public Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteConsult(DeleteDto request);
    }
}
