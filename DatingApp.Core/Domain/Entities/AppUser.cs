using DatingApp.Core.DTOs;

namespace DatingApp.Core.Domain.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public string? Gender { get; set; }
    public string? Introduction { get; set; }
    public string? LookingFor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public List<Photo> Photos { get; set; }
    public int Age
    {
        get {
            return DateOfBirth.CalculateAge();
        }
    }


}

public static class AppUserExtensions
{
    public static int CalculateAge(this DateOnly dateOfBirth)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - dateOfBirth.Year;
        if (dateOfBirth.AddYears(age) > today) age--;

        return age;
    }

    public static AppUserDTO ToMemberDTO(this AppUser appUser) 
    {
        return new AppUserDTO() {
            Id = appUser.Id,
            UserName = appUser.UserName,
            KnownAs = appUser.KnownAs,
            Created = appUser.Created,
            LastActive = appUser.LastActive,
            Gender = appUser.Gender,
            Introduction = appUser.Introduction,
            LookingFor = appUser.LookingFor,
            Interests = appUser.Interests,
            City = appUser.City,
            Country = appUser.Country,
            Photos = appUser.Photos.Select(photo => photo.ToPhotoDTO()).ToList()        
        };
    }
}
