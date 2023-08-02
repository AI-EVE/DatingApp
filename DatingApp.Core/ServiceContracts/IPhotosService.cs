using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Core.ServiceContracts;

public interface IPhotosService
{
    Task<ImageUploadResult> UploadPhoto(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);    
}