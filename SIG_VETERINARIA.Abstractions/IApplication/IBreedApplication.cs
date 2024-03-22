using SIG_VETERINARIA.DTOs.Breeds;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Abstractions.IApplication
{
    public interface IBreedApplication
    {
        public Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDTO request);
        public Task<ResultDto<int>> CreateBreed(BreedCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteBreed(DeleteDto request);
    }
}
