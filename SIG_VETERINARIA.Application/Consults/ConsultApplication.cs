using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Consults;

namespace SIG_VETERINARIA.Application.Consults
{
    public class ConsultApplication : IConsultApplication
    {
        private readonly IConsultService consultService;

        public ConsultApplication(IConsultService consultService)
        {
            this.consultService = consultService;
        }

        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDTO request)
        {
            return await this.consultService.CreateConsult(request);
        }

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            return await this.consultService.DeleteConsult(request);
        }

        public async Task<ResultDto<ConsultListResponseDTO>> GetConsults(ConsultListRequestDTO request)
        {
            return await this.consultService.GetConsults(request);
        }
    }
}
