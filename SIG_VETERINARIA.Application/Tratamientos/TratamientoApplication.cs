using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Application.Tratamientos
{
    public class TratamientoApplication : ITratamientoApplication
    {
        private readonly ITratamientosService _service;

        public TratamientoApplication(ITratamientosService service)
        {
            _service = service;
        }

        public async Task<ResultDto<int>> CreateTratamiento(TratamientosCreateRequestDTO request)
        {
            return await this._service.CreateTratamiento(request);
        }

        public async Task<ResultDto<int>> DeleteTratamiento(DeleteDto request)
        {
            return await this._service.DeleteTratamiento(request);
        }

        public async Task<ResultDto<TratamientosListResponseDTO>> ListTratamientos(TratamientosListRequestDTO request)
        {
            return await this._service.ListTratamientos(request);
        }
    }
}
