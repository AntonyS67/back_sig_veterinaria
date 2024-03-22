using SIG_VETERINARIA.DTOs.Breeds;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Abstractions.IServices
{
    public interface IBreedService
    {
        public Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDTO request);
        public Task<ResultDto<int>> CreateBreed(BreedCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteBreed(DeleteDto request);
    }
}
