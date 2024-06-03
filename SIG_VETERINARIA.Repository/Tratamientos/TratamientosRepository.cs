using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Tratamientos;

namespace SIG_VETERINARIA.Repository.Tratamientos
{
    public class TratamientosRepository : ITratamientosRepository
    {
        private string _connectionString;

        public TratamientosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateTratamiento(TratamientosCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);
                parameters.Add("@p_detalle", request.detalle);
                parameters.Add("@p_diagnostico_id", request.diagnostico_id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_TRATAMIENTO", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteTratamiento(DeleteDto request)
        {
            ResultDto<int> resultDto = new ResultDto<int>();
            try
            {
                DynamicParameters parameteres = new DynamicParameters();
                parameteres.Add("@p_id", request.id);
                using (var cn = new SqlConnection(_connectionString))
                {
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_TRATAMIENTO", parameteres, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            resultDto.Item = Convert.ToInt32(lector["id"].ToString());
                            resultDto.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion eliminada" : "No se pudo eliminar la informacion";
                            resultDto.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultDto.MessageException = ex.Message;
                resultDto.IsSuccess = false;
            }
            return resultDto;
        }

        public async Task<ResultDto<TratamientoDetailResponseDTO>> GetDetailTratamiento(int id)
        {
            ResultDto<TratamientoDetailResponseDTO> result = new ResultDto<TratamientoDetailResponseDTO>();
            TratamientoDetailResponseDTO item = new TratamientoDetailResponseDTO();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", id);
                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<TratamientoDetailResponseDTO>("SP_DETAIL_TRATAMIENTO", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (TratamientoDetailResponseDTO)query.FirstOrDefault();
                    result.IsSuccess = query.Any();
                    result.Message = query.Any() ? "Informacion encontrada" : "No se encontro informacion";
                    result.Item = item;
                }
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDto<TratamientosListResponseDTO>> ListTratamientos(TratamientosListRequestDTO request)
        {
            ResultDto<TratamientosListResponseDTO> res = new ResultDto<TratamientosListResponseDTO>();
            List<TratamientosListResponseDTO> list = new List<TratamientosListResponseDTO>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);
                parameters.Add("@p_diagnostico_id", request.diagnostico_id);

                using (var cn = new SqlConnection(_connectionString))
                {

                    list = (List<TratamientosListResponseDTO>)await cn.QueryAsync<TratamientosListResponseDTO>("SP_LIST_TRATAMIENTOS", parameters, commandType: System.Data.CommandType.StoredProcedure);

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
