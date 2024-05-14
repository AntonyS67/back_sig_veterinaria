using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Products;

namespace SIG_VETERINARIA.Application.Products
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService _productService;

        public ProductApplication(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDTO request)
        {
            return await _productService.CreateProduct(request);
        }

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            return await _productService.DeleteProduct(request);
        }

        public async Task<ResultDto<ProductListResponseDTO>> GetProducts(ProductListRequestDTO request)
        {
            return await this._productService.GetProducts(request);
        }
    }
}
