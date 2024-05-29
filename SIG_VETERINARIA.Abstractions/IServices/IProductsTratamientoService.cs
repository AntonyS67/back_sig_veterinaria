using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Abstractions.IServices
{
    public interface IProductsTratamientoService
    {
        public Task<ResultDto<ProductsTratamientoListResponseDTO>> GetProductsTratamiento(ProductsTratamientoListRequestDTO request);
        public Task<ResultDto<int>> CreateProductTratamiento(List<ProductsTratamientoCreateRequestDTO> request);
        public Task<ResultDto<int>> DeleteProductTratamiento(int tratamiento_id);
    }
}
