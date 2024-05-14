using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Products;

namespace SIG_VETERINARIA.Repository.Products
{
    public class ProductRepository : IProductRespository
    {
        private string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_name", request.name);
                    parameters.Add("@p_cost", request.cost);
                    parameters.Add("@p_price", request.price);
                    parameters.Add("@p_stock", request.stock);
                    parameters.Add("@p_proveedor", request.proveedor);
                    parameters.Add("@p_status_product", request.status_product);
                    parameters.Add("@p_category_id", request.category_id);
                    parameters.Add("@p_photo", request.uri_photo);
                    parameters.Add("@p_public_id", request.public_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_PRODUCTS", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion registrada o actualizada correctamente" : "No se pudo guardar la informacion";
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0;
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

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_PRODUCT", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion eliminada" : "No se pudo eliminar la informacion";
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

        public async Task<ResultDto<ProductListResponseDTO>> GetProductDetail(DeleteDto request)
        {
            ResultDto<ProductListResponseDTO> res = new ResultDto<ProductListResponseDTO>();
            ProductListResponseDTO item = new ProductListResponseDTO();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);
                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<ProductListResponseDTO>("SP_DETAIL_PRODUCT", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (ProductListResponseDTO)query.FirstOrDefault();
                    res.IsSuccess = query.Any();
                    res.Message = query.Any() ? "Informacion encontrada" : "No se encontro informacion";
                    res.Item = item;
                }
            }
            catch
            (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<ProductListResponseDTO>> GetProducts(ProductListRequestDTO request)
        {
            ResultDto<ProductListResponseDTO> result = new ResultDto<ProductListResponseDTO>();
            List<ProductListResponseDTO> list = new List<ProductListResponseDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);

                    list = (List<ProductListResponseDTO>)await cn.QueryAsync<ProductListResponseDTO>("SP_LIST_PRODUCTS", parameters, commandType: System.Data.CommandType.StoredProcedure);

                    result.IsSuccess = list.Count > 0;
                    result.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    result.Data = list.ToList();
                    result.Total = list.Count > 0 ? list[0].totalRecords : 0;
                }

            }
            catch (Exception e)
            {
                result.MessageException = e.Message;
                result.IsSuccess = false;
            }
            return result;
        }
    }
}
