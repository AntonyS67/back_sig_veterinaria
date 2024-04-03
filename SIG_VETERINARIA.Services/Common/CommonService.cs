using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SIG_VETERINARIA.Abstractions.IServices;
using SIG_VETERINARIA.DTOs.Clients;

namespace SIG_VETERINARIA.Services.Common
{
    public class CommonService : ICommonService
    {
        private string _cloudinaryUri;

        public CommonService(
            IConfiguration configuration)
        {
            _cloudinaryUri = configuration.GetSection("Cloudinary").GetSection("URL").Value;
        }
        public async Task<ClientResultUploadImageDTO> SaveImage(IFormFile photo)
        {
            ClientResultUploadImageDTO result = new ClientResultUploadImageDTO();
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
                result.isSuccess = true;
                result.uploadResult = uploadResult;
            }
            catch (Exception ex)
            {
                result.messageException = ex.Message;
                result.isSuccess = false;
            }
            return result;
        }

        public async Task<string> DeleteImage(string publicId)
        {
            try
            {
                Cloudinary cloudinary = new Cloudinary(_cloudinaryUri);
                var deleteParams = new DeletionParams(publicId);
                var result = await cloudinary.DestroyAsync(deleteParams);
                return result.Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
