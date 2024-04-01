using SIG_VETERINARIA.DTOs.Clients;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Abstractions.IRepository
{
    public interface IClientRepository
    {
        public Task<ResultDto<ClientListResponseDTO>> GetClients(ClientListRequestDTO request);
        public Task<ResultDto<int>> CreateClient(ClientCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteClient(DeleteDto request);
        public Task<ResultDto<ClientDetailResponseDto>> GetClientDetail(DeleteDto request);
    }
}
