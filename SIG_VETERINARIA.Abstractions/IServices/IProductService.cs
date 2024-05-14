using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Products;

namespace SIG_VETERINARIA.Abstractions.IServices
{
    public interface IProductService
    {
        public Task<ResultDto<ProductListResponseDTO>> GetProducts(ProductListRequestDTO request);
        public Task<ResultDto<int>> CreateProduct(ProductCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteProduct(DeleteDto request);
    }
}
