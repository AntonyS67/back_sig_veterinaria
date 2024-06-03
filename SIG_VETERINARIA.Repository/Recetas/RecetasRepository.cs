using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Recetas;

namespace SIG_VETERINARIA.Repository.Recetas
{
    public class RecetasRepository : IRecetasRepository
    {
        private string _connectionString;

        public RecetasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public async Task<ResultDto<int>> CreateReceta(RecetasCreateRequestDTO request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_description", request.description);
                    parameters.Add("@p_indicaciones", request.indicaciones);
                    parameters.Add("@p_paciente_id", request.paciente_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_RECETA", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion creada o actualizada correctamente" : "No se pudo guardar la informacion";
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

        public async Task<ResultDto<int>> DeleteReceta(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_RECETA", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Informacion eliminada correctamente" : "No se pudo eliminar la informacion";
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

        public async Task<ResultDto<RecetasListResponseDTO>> GetAllRecetas(RecetasListRequestDTO request)
        {
            ResultDto<RecetasListResponseDTO> res = new ResultDto<RecetasListResponseDTO>();
            List<RecetasListResponseDTO> list = new List<RecetasListResponseDTO>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_pacient_id", request.pacient_id);

                    list = (List<RecetasListResponseDTO>)await cn.QueryAsync<RecetasListResponseDTO>("SP_LIST_RECETAS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    res.Message = list.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                    res.IsSuccess = list.Count > 0;
                    res.Total = list.Count > 0 ? list[0].totalRecords : 0;
                    res.Data = list.ToList();
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
    }
}
