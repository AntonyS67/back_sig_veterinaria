using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Categories;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDTO request)
        {
            return await this._categoryRepository.CreateCategory(request);
        }

        public async Task<ResultDto<int>> DeleteCategory(DeleteDto request)
        {
            return await this._categoryRepository.DeleteCategory(request);
        }

        public async Task<ResultDto<CategoriesListResponseDTO>> GetCategories(CategoriesListRequestDTO request)
        {
            return await this._categoryRepository.GetCategories(request);
        }
    }
}
