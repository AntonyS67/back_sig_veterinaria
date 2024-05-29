using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Repository.Tratamientos
{
    public class ProductTratamientoRepository : IProductsTratamiento
    {
        private string _connectionString;

        public ProductTratamientoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateProductTratamiento(List<ProductsTratamientoCreateRequestDTO> _request)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                foreach (ProductsTratamientoCreateRequestDTO request in _request)
                {
                    using (var cn = new SqlConnection(_connectionString))
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@p_id", request.id);
                        parameters.Add("@p_tratamiento_id", request.tratamiento_id);
                        parameters.Add("@p_product_id", request.product_id);

                        using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_PRODUCTS_TRATAMIENTOS", parameters, commandType: System.Data.CommandType.StoredProcedure))
                        {
                            while (lector.Read())
                            {
                                result.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion registrada" : "No se pudo guardar la informacion";
                                result.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0;
                                result.Item = Convert.ToInt32(lector["id"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<int>> DeleteProductTratamiento(int tratamiento_id)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_tratamiento_id", tratamiento_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_PRODUCT_TRATAMIENTO", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion eliminada" : "No se pudo eliminar la informacion";
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0;
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<ProductsTratamientoListResponseDTO>> GetProductsTratamiento(ProductsTratamientoListRequestDTO request)
        {
            ResultDto<ProductsTratamientoListResponseDTO> res = new ResultDto<ProductsTratamientoListResponseDTO>();
            List<ProductsTratamientoListResponseDTO> list = new List<ProductsTratamientoListResponseDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_tratamiento_id", request.tratamiento_id);

                    list = (List<ProductsTratamientoListResponseDTO>)await cn.QueryAsync<ProductsTratamientoListResponseDTO>("SP_LIST_PRODUCTS_TRATAMIENTOS", parameters, commandType: System.Data.CommandType.StoredProcedure);


                    res.IsSuccess = list.Count > 0;
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.Data = list.ToList();
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
                }
            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }
    }
}
