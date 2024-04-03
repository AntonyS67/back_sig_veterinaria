using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Patients;

namespace SIG_VETERINARIA.Services.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ICommonService _commonService;

        public PatientService(IPatientRepository patientRepository, ICommonService commonService)
        {
            _patientRepository = patientRepository;
            _commonService = commonService;
        }

        public async Task<ResultDto<int>> CreatePatient(PatientCreateRequestDTO request)
        {
            if (request.photo != null)
            {
                var res = await _commonService.SaveImage(request.photo);
                if (res.isSuccess)
                {
                    request.uri_photo = res.uploadResult?.SecureUrl.ToString();
                    request.public_id = res.uploadResult?.PublicId;
                }
            }
            return await _patientRepository.CreatePatient(request);
        }

        public async Task<ResultDto<int>> DeletePatient(DeleteDto request)
        {
            var patient = await _patientRepository.GetPatientDetail(request);
            await _commonService.DeleteImage(patient.Item?.public_id);
            return await _patientRepository.DeletePatient(request);
        }

        public async Task<ResultDto<PatientListResponseDTO>> GetPatients(PatientListRequestDTO request)
        {
            return await _patientRepository.GetPatients(request);
        }
    }
}
