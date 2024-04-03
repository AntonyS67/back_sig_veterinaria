using Microsoft.AspNetCore.Http;
using SIG_VETERINARIA.DTOs.Clients;

namespace SIG_VETERINARIA.Abstractions.IServices
{
    public interface ICommonService
    {
        public Task<ClientResultUploadImageDTO> SaveImage(IFormFile photo);
        public Task<string> DeleteImage(string publicId);
    }
}
