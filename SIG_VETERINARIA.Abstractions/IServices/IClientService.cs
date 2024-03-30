using Microsoft.AspNetCore.Http;
using SIG_VETERINARIA.DTOs.Clients;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Abstractions.IServices
{
    public interface IClientService
    {
        public Task<ResultDto<ClientListResponseDTO>> GetClients(ClientListRequestDTO request);
        public Task<ResultDto<int>> CreateClient(ClientCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteClient(DeleteDto request);
        public Task<string> SaveImage(IFormFile photo);
    }
}
