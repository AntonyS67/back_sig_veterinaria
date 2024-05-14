using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Exams;

namespace SIG_VETERINARIA.Repository.Exams
{
    public class ExamRepository : IExamRepository
    {
        private string _connectionString;

        public ExamRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_mucosa", request.mucosa);
                    parameters.Add("@p_piel", request.piel);
                    parameters.Add("@p_conjuntival", request.conjuntival);
                    parameters.Add("@p_oral", request.oral);
                    parameters.Add("@p_sis_reproductor", request.sis_reproductor);
                    parameters.Add("@p_rectal", request.rectal);
                    parameters.Add("@p_ojos", request.ojos);
                    parameters.Add("@p_nodulos_linfaticos", request.nodulos_linfaticos);
                    parameters.Add("@p_locomocion", request.locomocion);
                    parameters.Add("@p_sis_cardiovascular", request.sis_cardiovascular);
                    parameters.Add("@p_sis_respiratorio", request.sis_respiratorio);
                    parameters.Add("@p_sis_digestivo", request.sis_digestivo);
                    parameters.Add("@p_sis_urinario", request.sis_urinario);
                    parameters.Add("@p_id_consulta", request.consult_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_EXAMS", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion ha sido creada o actualizada correctamente" : "No se pudo guardar la informacion";

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

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);
                using (var cn = new SqlConnection(_connectionString))
                {
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_EXAM", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion ha sido eliminada correctamente" : "No se pudo eliminar la informacion";

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

        public async Task<ResultDto<ExamListResponseDTO>> GetExams(ExamListRequestDTO request)
        {
            ResultDto<ExamListResponseDTO> res = new ResultDto<ExamListResponseDTO>();
            List<ExamListResponseDTO> list = new List<ExamListResponseDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_consult_id", request.consult_id);

                    list = (List<ExamListResponseDTO>)await cn.QueryAsync<ExamListResponseDTO>("SP_LIST_EXAMS", parameters, commandType: System.Data.CommandType.StoredProcedure);

                }
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = list.ToList();
                res.Total = list.Count > 0 ? list[0].totalRecords : 0;
            }
            catch (Exception e)
            {
                res.MessageException = e.Message;
                res.IsSuccess = false;
            }
            return res;
        }
    }
}
