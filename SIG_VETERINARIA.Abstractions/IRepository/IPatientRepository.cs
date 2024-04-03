using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Patients;

namespace SIG_VETERINARIA.Abstractions.IRepository
{
    public interface IPatientRepository
    {
        public Task<ResultDto<PatientListResponseDTO>> GetPatients(PatientListRequestDTO request);
        public Task<ResultDto<int>> CreatePatient(PatientCreateRequestDTO request);
        public Task<ResultDto<int>> DeletePatient(DeleteDto request);
        public Task<ResultDto<PatientListResponseDTO>> GetPatientDetail(DeleteDto request);
    }
}
