using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Breeds;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Repository.Breeds
{
    public class BreedRepository : IBreedRepository
    {
        private string _connectionString = "";
        public BreedRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateBreed(BreedCreateRequestDTO request)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_name", request.name);
                    parameters.Add("@p_specie_id", request.specie_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_BREED", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            result.Item = Convert.ToInt32(lector["id"].ToString());
                            result.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            result.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion guardada con exito" : "Informacion no se pudo guardar";

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

        public async Task<ResultDto<int>> DeleteBreed(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_BREED", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion guardada con exito" : "Informacion no se pudo guardar";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDTO request)
        {
            ResultDto<BreedListResponseDto> res = new ResultDto<BreedListResponseDto>();
            List<BreedListResponseDto> list = new List<BreedListResponseDto>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_indice", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<BreedListResponseDto>)await cn.QueryAsync<BreedListResponseDto>("SP_LIST_BREEDS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }


                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Información encontrada" : "No se encontro información";
                res.Data = list.ToList();
                res.Total = list.Count > 0 ? list[0].totalRegisters : 0;
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
