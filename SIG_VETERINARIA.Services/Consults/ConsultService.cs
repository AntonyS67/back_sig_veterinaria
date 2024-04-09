using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Consults;

namespace SIG_VETERINARIA.Services.Consults
{
    public class ConsultService : IConsultService
    {
        private readonly IConsultRepository consultRepository;

        public ConsultService(IConsultRepository consultRepository)
        {
            this.consultRepository = consultRepository;
        }

        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDTO request)
        {
            return await this.consultRepository.CreateConsult(request);
        }

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            return await this.consultRepository.DeleteConsult(request);
        }

        public async Task<ResultDto<ConsultListResponseDTO>> GetConsults(ConsultListRequestDTO request)
        {
            return await this.consultRepository.GetConsults(request);
        }
    }
}
