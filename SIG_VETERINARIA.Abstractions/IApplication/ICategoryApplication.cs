using SIG_VETERINARIA.DTOs.Categories;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Abstractions.IApplication
{
    public interface ICategoryApplication
    {
        public Task<ResultDto<CategoriesListResponseDTO>> GetCategories(CategoriesListRequestDTO request);
        public Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteCategory(DeleteDto request);
    }
}
