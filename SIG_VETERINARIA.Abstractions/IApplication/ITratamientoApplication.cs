using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Abstractions.IApplication
{
    public interface ITratamientoApplication
    {
        public Task<ResultDto<TratamientosListResponseDTO>> ListTratamientos(TratamientosListRequestDTO request);
        public Task<ResultDto<int>> CreateTratamiento(TratamientosCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteTratamiento(DeleteDto request);
    }
}
