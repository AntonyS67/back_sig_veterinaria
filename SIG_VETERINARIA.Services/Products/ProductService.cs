using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Products;

namespace SIG_VETERINARIA.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRespository productRespository;
        private readonly ICommonService commonService;

        public ProductService(IProductRespository productRespository, ICommonService commonService)
        {
            this.productRespository = productRespository;
            this.commonService = commonService;

        }

        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDTO request)
        {
            if (request.photo != null)
            {
                var res = await commonService.SaveImage(request.photo);
                if (res.isSuccess)
                {
                    request.uri_photo = res.uploadResult?.SecureUrl.ToString();
                    request.public_id = res.uploadResult?.PublicId;
                }
            }
            return await productRespository.CreateProduct(request);
        }

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            var product = await productRespository.GetProductDetail(request);
            await commonService.DeleteImage(product.Item?.public_id);
            return await productRespository.DeleteProduct(request);
        }

        public async Task<ResultDto<ProductListResponseDTO>> GetProducts(ProductListRequestDTO request)
        {
            return await productRespository.GetProducts(request);

        }
    }
}
