using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Breeds;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Application.Breed
{
    public class BreedApplication : IBreedApplication
    {
        private IBreedService _breedService;

        public BreedApplication(IBreedService breedService)
        {
            _breedService = breedService;
        }

        public async Task<ResultDto<int>> CreateBreed(BreedCreateRequestDTO request)
        {
            return await this._breedService.CreateBreed(request);
        }

        public async Task<ResultDto<int>> DeleteBreed(DeleteDto request)
        {
            return await this._breedService.DeleteBreed(request);
        }

        public async Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDTO request)
        {
            return await this._breedService.GetBreeds(request);
        }
    }
}
