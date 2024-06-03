using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Recetas;

namespace SIG_VETERINARIA.Services.Recetas
{
    public class RecetasService : IRecetasService
    {
        private readonly IRecetasRepository recetasRepository;

        public RecetasService(IRecetasRepository recetasRepository)
        {
            this.recetasRepository = recetasRepository;
        }

        public async Task<ResultDto<int>> CreateReceta(RecetasCreateRequestDTO request)
        {
            return await this.recetasRepository.CreateReceta(request);
        }

        public async Task<ResultDto<int>> DeleteReceta(DeleteDto request)
        {
            return await this.recetasRepository.DeleteReceta(request);
        }

        public async Task<ResultDto<RecetasListResponseDTO>> DetailReceta(DeleteDto request)
        {
            return await this.recetasRepository.DetailReceta(request);
        }

        public async Task<ResultDto<RecetasListResponseDTO>> GetAllRecetas(RecetasListRequestDTO request)
        {
            return await this.recetasRepository.GetAllRecetas(request);
        }
    }
}
