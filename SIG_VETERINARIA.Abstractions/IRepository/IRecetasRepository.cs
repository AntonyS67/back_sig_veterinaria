using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Recetas;

namespace SIG_VETERINARIA.Abstractions.IRepository
{
    public interface IRecetasRepository
    {
        public Task<ResultDto<RecetasListResponseDTO>> GetAllRecetas(RecetasListRequestDTO request);
        public Task<ResultDto<int>> CreateReceta(RecetasCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteReceta(DeleteDto request);
        public Task<ResultDto<RecetasListResponseDTO>> DetailReceta(DeleteDto request);
    }
}
