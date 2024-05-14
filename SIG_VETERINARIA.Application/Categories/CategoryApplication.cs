using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Categories;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Application.Categories
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryService _categoryService;

        public CategoryApplication(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDTO request)
        {
            return await _categoryService.CreateCategory(request);
        }

        public async Task<ResultDto<int>> DeleteCategory(DeleteDto request)
        {
            return await _categoryService.DeleteCategory(request);
        }

        public async Task<ResultDto<CategoriesListResponseDTO>> GetCategories(CategoriesListRequestDTO request)
        {
            return await _categoryService.GetCategories(request);
        }
    }
}
