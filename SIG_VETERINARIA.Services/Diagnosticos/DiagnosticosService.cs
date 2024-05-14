using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.Services.Diagnosticos
{
    public class DiagnosticosService : IDiagnosticoService
    {
        private readonly IDiagnosticoRepository diagnosticoRepository;

        public DiagnosticosService(IDiagnosticoRepository diagnosticoRepository)
        {
            this.diagnosticoRepository = diagnosticoRepository;
        }

        public async Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDTO request)
        {
            return await this.diagnosticoRepository.CreateDiagnostico(request);
        }

        public async Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request)
        {
            return await this.diagnosticoRepository.DeleteDiagnostico(request);
        }

        public async Task<ResultDto<DiagnosticoListResponseDTO>> GetDiagnosticos(DiagnosticoListRequestDTO request)
        {
            return await this.diagnosticoRepository.GetDiagnosticos(request);
        }
    }
}
