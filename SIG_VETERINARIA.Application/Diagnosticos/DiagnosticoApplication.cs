using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.Application.Diagnosticos
{
    public class DiagnosticoApplication : IDiagnosticoApplication
    {
        private readonly IDiagnosticoService diagnosticoService;

        public DiagnosticoApplication(IDiagnosticoService diagnosticoService)
        {
            this.diagnosticoService = diagnosticoService;
        }

        public async Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDTO request)
        {
            return await this.diagnosticoService.CreateDiagnostico(request);
        }

        public async Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request)
        {
            return await this.diagnosticoService.DeleteDiagnostico(request);
        }

        public async Task<ResultDto<DiagnosticoListResponseDTO>> GetDiagnosticos(DiagnosticoListRequestDTO request)
        {
            return await this.diagnosticoService.GetDiagnosticos(request);
        }
    }
}
