using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingApp.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DatingApp.Core.Services;

public class PhotosService : IPhotosService
{
    private readonly Cloudinary _cloudinary;

    public PhotosService(IConfiguration config)
    {
        var account = new Account(
            config["CloudinarySettings:CloudName"],
            config["CloudinarySettings:ApiKey"],
            config["CloudinarySettings:ApiSecret"]
        );
        _cloudinary = new Cloudinary(account);
    }


    public async Task<ImageUploadResult> UploadPhoto(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();

        if(file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation()
                    .Height(500)
                    .Width(500)
                    .Crop("fill")
                    .Gravity("face"),
                Folder = "DatingApp"
            };

            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }

        return uploadResult;
    }

    
    public async Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
        return await _cloudinary.DestroyAsync(new DeletionParams(publicId));
    }
}