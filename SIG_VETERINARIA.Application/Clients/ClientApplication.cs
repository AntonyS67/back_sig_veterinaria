using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Clients;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Application.Clients
{
    public class ClientApplication : IClientApplication
    {
        private readonly IClientService _clientService;

        public ClientApplication(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDTO request)
        {
            return await _clientService.CreateClient(request);
        }

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            return await _clientService.DeleteClient(request);
        }

        public async Task<ResultDto<ClientListResponseDTO>> GetClients(ClientListRequestDTO request)
        {
            return await _clientService.GetClients(request);
        }
    }
}
