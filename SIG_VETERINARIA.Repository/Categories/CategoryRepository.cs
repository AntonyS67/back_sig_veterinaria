using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Categories;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private string _connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateCategory(CategoriesCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_name", request.name);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_CATEGORY", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion registrada o actualizada" : "No se pudo guardar la informacion";
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

        public async Task<ResultDto<int>> DeleteCategory(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_CATEGORY", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion eliminada" : "No se pudo eliminar la informacion";
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

        public async Task<ResultDto<CategoriesListResponseDTO>> GetCategories(CategoriesListRequestDTO request)
        {
            ResultDto<CategoriesListResponseDTO> res = new ResultDto<CategoriesListResponseDTO>();
            List<CategoriesListResponseDTO> list = new List<CategoriesListResponseDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);

                    list = (List<CategoriesListResponseDTO>)await cn.QueryAsync<CategoriesListResponseDTO>("SP_LIST_CATEGORIES", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }

                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.IsSuccess = list.Count > 0;
                res.Data = list.ToList();
                res.Total = list.Count > 0 ? list[0].totalRecords : 0;

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
