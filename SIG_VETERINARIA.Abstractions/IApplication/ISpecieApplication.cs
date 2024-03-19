using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Species;

namespace SIG_VETERINARIA.Abstractions.IApplication
{
    public interface ISpecieApplication
    {
        public Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request);
        public Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request);
        public Task<ResultDto<int>> DeleteSpecie(DeleteDto request);

    }
}
