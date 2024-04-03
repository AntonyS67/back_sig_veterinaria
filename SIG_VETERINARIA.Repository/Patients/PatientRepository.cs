using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Patients;

namespace SIG_VETERINARIA.Repository.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreatePatient(PatientCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_names", request.names);
                    parameters.Add("@p_birthday", request.birthday);
                    parameters.Add("@p_age", request.age);
                    parameters.Add("@p_sex", request.sex);
                    parameters.Add("@p_color", request.color);
                    parameters.Add("@p_fur", request.fur);
                    parameters.Add("@p_particularity", request.particularity);
                    parameters.Add("@p_allergy", request.allergy);
                    parameters.Add("@p_breed_id", request.breed_id);
                    parameters.Add("@p_client", request.client_id);
                    parameters.Add("@p_public_id", request.public_id);
                    parameters.Add("@p_photo", request.uri_photo);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_PATIENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion registrada o actualizada correctamente" : "No se pudo registrar o actualizar la informacion";

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

        public async Task<ResultDto<int>> DeletePatient(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_PATIENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion eliminada correctamente" : "No se pudo eliminarla informacion";

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

        public async Task<ResultDto<PatientListResponseDTO>> GetPatientDetail(DeleteDto request)
        {
            ResultDto<PatientListResponseDTO> res = new ResultDto<PatientListResponseDTO>();
            PatientListResponseDTO item = new PatientListResponseDTO();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);
                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<PatientListResponseDTO>("SP_GET_PATIENT", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (PatientListResponseDTO)query.FirstOrDefault();
                    res.IsSuccess = query.Any() ? true : false;
                    res.Message = query.Any() ? "Informacion encontrada" : "No se encontro informacion";
                    res.Item = item;
                }
            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<PatientListResponseDTO>> GetPatients(PatientListRequestDTO request)
        {
            ResultDto<PatientListResponseDTO> res = new ResultDto<PatientListResponseDTO>();
            List<PatientListResponseDTO> list = new List<PatientListResponseDTO>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_indice", request.index);
                parameters.Add("@p_limit", request.limit);
                parameters.Add("@p_client_id", request.client_id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<PatientListResponseDTO>)await cn.QueryAsync<PatientListResponseDTO>("SP_LIST_PATIENTS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
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
