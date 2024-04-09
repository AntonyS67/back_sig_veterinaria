using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Consults;

namespace SIG_VETERINARIA.Repository.Consults
{
    public class ConsultRepository : IConsultRepository
    {
        private string _connectionString;

        public ConsultRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("Connection");
        }
        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(this._connectionString))
                {

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_reason", request.reason);
                    parameters.Add("@p_antecedents", request.antecedents);
                    parameters.Add("@p_diseases", request.diseases);
                    parameters.Add("@p_next_consult", request.next_consult);
                    parameters.Add("@p_patient_id", request.patient_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_CONSULT", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion ha sido creada o actualizada correctamente" : "No se pudo guardar la inforamcion";

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

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_CONSULT", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion ha sido eliminda correctamente" : "No se pudo eliminar la inforamcion";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<ConsultListResponseDTO>> GetConsults(ConsultListRequestDTO request)
        {
            ResultDto<ConsultListResponseDTO> res = new ResultDto<ConsultListResponseDTO>();
            List<ConsultListResponseDTO> List = new List<ConsultListResponseDTO>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_indice", request.index);
                parameters.Add("@p_limit", request.limit);
                parameters.Add("@@p_patient_id", request.patient_id);


                using (var cn = new SqlConnection(_connectionString))
                {
                    List = (List<ConsultListResponseDTO>)await cn.QueryAsync<ConsultListResponseDTO>("SP_LIST_CONSULTS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }

                res.IsSuccess = List.Count > 0 ? true : false;
                res.Message = List.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = List.ToList();
                res.Total = List.Count > 0 ? List[0].totalRecords : 0;
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
