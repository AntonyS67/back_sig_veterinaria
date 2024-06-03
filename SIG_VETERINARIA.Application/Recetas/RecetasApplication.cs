using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Recetas;

namespace SIG_VETERINARIA.Application.Recetas
{
    public class RecetasApplication : IRecetasApplication
    {
        private readonly IRecetasService _recetasService;

        public RecetasApplication(IRecetasService recetasService)
        {
            _recetasService = recetasService;
        }

        public async Task<ResultDto<int>> CreateReceta(RecetasCreateRequestDTO request)
        {
            return await this._recetasService.CreateReceta(request);
        }

        public async Task<ResultDto<int>> DeleteReceta(DeleteDto request)
        {
            return await this._recetasService.DeleteReceta(request);
        }

        public async Task<ResultDto<RecetasListResponseDTO>> GetAllRecetas(RecetasListRequestDTO request)
        {
            return await this._recetasService.GetAllRecetas(request);
        }
    }
}
