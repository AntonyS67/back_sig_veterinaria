using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Diagnosticos;
using System.Data;

namespace SIG_VETERINARIA.Repository.Diagnosticos
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private string _connectionString;

        public DiagnosticoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_detalle", request.detalle);
                    parameters.Add("@p_fecha_diagnostico", request.fecha_diagnostico);
                    parameters.Add("@p_consult_id", request.consult_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_DIAGNOSTICO", parameters, commandType: CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion registrada o actualizada correctamente" : "No se pudo guardar la informacion";
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;

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

        public async Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_DIAGNOSTICO", parameters, commandType: CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion eliminada" : "No se pudo eliminar la informacion";
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                        }
                    }
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

        public async Task<ResultDto<DiagnosticoListResponseDTO>> GetDiagnosticos(DiagnosticoListRequestDTO request)
        {
            ResultDto<DiagnosticoListResponseDTO> res = new ResultDto<DiagnosticoListResponseDTO>();
            List<DiagnosticoListResponseDTO> list = new List<DiagnosticoListResponseDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_consult_id", request.consult_id);

                    list = (List<DiagnosticoListResponseDTO>)await cn.QueryAsync<DiagnosticoListResponseDTO>("SP_LIST_DIAGNOSTICOS", parameters, commandType: CommandType.StoredProcedure);
                }

                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.IsSuccess = list.Count > 0 ? true : false;
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
