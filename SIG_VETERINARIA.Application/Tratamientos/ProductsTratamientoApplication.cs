using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Application.Tratamientos
{
    public class ProductsTratamientoApplication : IProductsTratamientoApplication
    {
        private readonly IProductsTratamientoService _service;

        public ProductsTratamientoApplication(IProductsTratamientoService service)
        {
            _service = service;
        }

        public async Task<ResultDto<int>> CreateProductTratamiento(List<ProductsTratamientoCreateRequestDTO> request)
        {
            return await this._service.CreateProductTratamiento(request);
        }

        public async Task<ResultDto<int>> DeleteProductTratamiento(int tratamiento_id)
        {
            return await this._service.DeleteProductTratamiento(tratamiento_id);
        }

        public async Task<ResultDto<ProductsTratamientoListResponseDTO>> GetProductsTratamiento(ProductsTratamientoListRequestDTO request)
        {
            return await this._service.GetProductsTratamiento(request);
        }
    }
}
