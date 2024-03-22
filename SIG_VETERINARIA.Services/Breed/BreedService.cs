using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Breeds;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Services.Breed
{
    public class BreedService : IBreedService
    {
        private IBreedRepository _breedRepository;

        public BreedService(IBreedRepository breedRepository)
        {
            _breedRepository = breedRepository;
        }

        public async Task<ResultDto<int>> CreateBreed(BreedCreateRequestDTO request)
        {
            return await this._breedRepository.CreateBreed(request);
        }

        public async Task<ResultDto<int>> DeleteBreed(DeleteDto request)
        {
            return await this._breedRepository.DeleteBreed(request);
        }

        public async Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDTO request)
        {
            return await this._breedRepository.GetBreeds(request);
        }
    }
}
