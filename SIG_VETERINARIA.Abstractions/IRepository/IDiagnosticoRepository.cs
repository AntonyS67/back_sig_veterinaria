﻿using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Diagnosticos;

namespace SIG_VETERINARIA.Abstractions.IRepository
{
    public interface IDiagnosticoRepository
    {
        public Task<ResultDto<DiagnosticoListResponseDTO>> GetDiagnosticos(DiagnosticoListRequestDTO request);
        public Task<ResultDto<int>> CreateDiagnostico(DiagnosticoCreateRequestDTO request);
        public Task<ResultDto<int>> DeleteDiagnostico(DeleteDto request);
    }
}
