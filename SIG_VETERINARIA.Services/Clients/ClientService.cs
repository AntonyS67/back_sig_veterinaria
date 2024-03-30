using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IRepository;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Clients;
using SIG_VETERINARIA.DTOs.Common;

namespace SIG_VETERINARIA.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private string _cloudinaryUri;

        public ClientService(
            IClientRepository clientRepository,
            IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _cloudinaryUri = configuration.GetSection("Cloudinary").GetSection("URL").Value;
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDTO request)
        {
            request.uri_photo = await this.SaveImage(request.photo);
            return await _clientRepository.CreateClient(request);
        }

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            return await _clientRepository.DeleteClient(request);
        }

        public async Task<ResultDto<ClientListResponseDTO>> GetClients(ClientListRequestDTO request)
        {
            return await _clientRepository.GetClients(request);
        }

        public async Task<string> SaveImage(IFormFile photo)
        {
            try
            {
                Cloudinary cloudinary = new Cloudinary(_cloudinaryUri);
                var fileName = photo.FileName;
                var fileWithPath = Path.Combine("Uploads", fileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                photo.CopyTo(stream);
                stream.Close();
                var uploadsParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileWithPath),
                    UseFilename = true,
                    Overwrite = true,
                    Folder = "sig_veterinary"
                };
                var uploadResult = cloudinary.Upload(uploadsParams);
                System.IO.File.Delete(fileWithPath);
                return uploadResult.SecureUri.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
