using System.Text.Json.Serialization;
using DatingApp.Core.DTOs;

namespace DatingApp.Core.Domain.Entities;

public class Photo
{
    public int Id { get; set; }
    public string? Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }
    public int AppUserId { get; set; }

    [JsonIgnore]
    public AppUser AppUser { get; set; }
}

public static class PhotoExtensions {
    public static PhotoDTO ToPhotoDTO(this Photo photo) {
        return new PhotoDTO {
            Id = photo.Id,
            Url = photo.Url,
            IsMain = photo.IsMain
        };
    }
}