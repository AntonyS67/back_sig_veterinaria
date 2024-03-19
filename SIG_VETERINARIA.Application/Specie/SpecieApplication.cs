using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Species;

namespace SIG_VETERINARIA.Application.Specie
{
    public class SpecieApplication : ISpecieApplication
    {
        private ISpecieService _specieService;

        public SpecieApplication(ISpecieService specieService)
        {
            _specieService = specieService;
        }

        public async Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request)
        {
            return await _specieService.CreateSpecie(request);
        }

        public async Task<ResultDto<int>> DeleteSpecie(DeleteDto request)
        {
            return await _specieService.DeleteSpecie(request);
        }

        public async Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request)
        {
            return await _specieService.GetAll(request);
        }
    }
}
