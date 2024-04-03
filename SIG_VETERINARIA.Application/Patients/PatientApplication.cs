using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Patients;

namespace SIG_VETERINARIA.Application.Patients
{
    public class PatientApplication : IPatientApplication
    {
        private readonly IPatientService _patientService;

        public PatientApplication(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<ResultDto<int>> CreatePatient(PatientCreateRequestDTO request)
        {
            return await _patientService.CreatePatient(request);
        }

        public async Task<ResultDto<int>> DeletePatient(DeleteDto request)
        {
            return await _patientService.DeletePatient(request);
        }

        public async Task<ResultDto<PatientListResponseDTO>> GetPatients(PatientListRequestDTO request)
        {
            return await _patientService.GetPatients(request);
        }
    }
}
