using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Services.Tratamientos
{
    public class TratamientoService : ITratamientosService
    {
        private readonly ITratamientosRepository _repository;

        public TratamientoService(ITratamientosRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto<int>> CreateTratamiento(TratamientosCreateRequestDTO request)
        {
            return await this._repository.CreateTratamiento(request);
        }

        public async Task<ResultDto<int>> DeleteTratamiento(DeleteDto request)
        {
            return await this._repository.DeleteTratamiento(request);
        }

        public async Task<ResultDto<TratamientoDetailResponseDTO>> GetDetailTratamiento(int id)
        {
            return await _repository.GetDetailTratamiento(id);
        }

        public async Task<ResultDto<TratamientosListResponseDTO>> ListTratamientos(TratamientosListRequestDTO request)
        {
            return await _repository.ListTratamientos(request);
        }
    }
}
