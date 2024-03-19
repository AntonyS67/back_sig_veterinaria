using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Species;

namespace SIG_VETERINARIA.Services.Specie
{
    public class SpecieService : ISpecieService
    {
        private ISpecieRepository _specieRepository;
        public SpecieService(ISpecieRepository specieRepository)
        {
            _specieRepository = specieRepository;
        }

        public async Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request)
        {
            return await _specieRepository.CreateSpecie(request);
        }

        public async Task<ResultDto<int>> DeleteSpecie(DeleteDto request)
        {
            return await _specieRepository.DeleteSpecie(request);
        }

        public async Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request)
        {
            return await _specieRepository.GetAll(request);
        }
    }
}
