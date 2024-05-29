using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Services.Tratamientos
{
    public class ProductsTratamientoService : IProductsTratamientoService
    {
        private readonly IProductsTratamiento _repository;

        public ProductsTratamientoService(IProductsTratamiento repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto<int>> CreateProductTratamiento(List<ProductsTratamientoCreateRequestDTO> request)
        {
            return await this._repository.CreateProductTratamiento(request);
        }

        public async Task<ResultDto<int>> DeleteProductTratamiento(int tratamiento_id)
        {
            return await this._repository.DeleteProductTratamiento(tratamiento_id);
        }

        public async Task<ResultDto<ProductsTratamientoListResponseDTO>> GetProductsTratamiento(ProductsTratamientoListRequestDTO request)
        {
            return await this._repository.GetProductsTratamiento(request);
        }
    }
}
