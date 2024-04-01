using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Clients;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Repository.Clients
{
    public class ClientRepository : IClientRepository
    {
        private string _connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {

                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_name", request.names);
                    parameters.Add("@p_lastnames", request.lastnames);
                    parameters.Add("@p_photo", request.uri_photo);
                    parameters.Add("@p_document_number", request.document_number);
                    parameters.Add("@p_document_type", request.document_type);
                    parameters.Add("@p_phone", request.phone);
                    parameters.Add("@p_address", request.address);
                    parameters.Add("@p_city", request.city);
                    parameters.Add("@p_email", request.email);
                    parameters.Add("@p_public_id", request.public_id);
                    parameters.Add("@p_signature", request.signature);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_CLIENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Información registrada o actualizada correctamente" : "No se pudo guardar la informacion";

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

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_CLIENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Información eliminada correctamente" : "No se pudo eliminar la informacion";
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

        public async Task<ResultDto<ClientDetailResponseDto>> GetClientDetail(DeleteDto request)
        {
            ResultDto<ClientDetailResponseDto> res = new ResultDto<ClientDetailResponseDto>();
            ClientDetailResponseDto item = new ClientDetailResponseDto();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<ClientDetailResponseDto>("SP_GET_CLIENT", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (ClientDetailResponseDto)query.FirstOrDefault();
                    res.IsSuccess = query.Any() ? true : false;
                    res.Message = query.Any() ? "Información encontrada" : "No se encontró información";
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

        public async Task<ResultDto<ClientListResponseDTO>> GetClients(ClientListRequestDTO request)
        {
            ResultDto<ClientListResponseDTO> result = new ResultDto<ClientListResponseDTO>();
            List<ClientListResponseDTO> list = new List<ClientListResponseDTO>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_indice", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<ClientListResponseDTO>)await cn.QueryAsync<ClientListResponseDTO>("SP_LIST_CLIENTS", parameters, commandType: System.Data.CommandType.StoredProcedure);

                }
                result.IsSuccess = list.Count > 0 ? true : false;
                result.Message = list.Count > 0 ? "Información encontrada" : "No se encontró información";
                result.Data = list.ToList();
                result.Total = list.Count > 0 ? list[0].totalRegisters : 0;
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
    }
}
