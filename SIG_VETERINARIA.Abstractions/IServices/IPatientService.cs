using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Patients;

namespace SIG_VETERINARIA.Abstractions.IServices
{
    public interface IPatientService
    {
        public Task<ResultDto<PatientListResponseDTO>> GetPatients(PatientListRequestDTO request);
        public Task<ResultDto<int>> CreatePatient(PatientCreateRequestDTO request);
        public Task<ResultDto<int>> DeletePatient(DeleteDto request);

    }
}
