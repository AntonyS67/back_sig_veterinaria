using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Products;

namespace SIG_VETERINARIA.Abstractions.IRepository
{
    public interface IProductRespository
    {
        public Task<ResultDto<ProductListResponseDTO>> GetProducts(ProductListRequestDTO request);
        public Task<ResultDto<int>> CreateProduct(ProductCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteProduct(DeleteDto request);
        public Task<ResultDto<ProductListResponseDTO>> GetProductDetail(DeleteDto request);
    }
}
