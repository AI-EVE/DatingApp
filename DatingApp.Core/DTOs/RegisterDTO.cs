using System.ComponentModel.DataAnnotations;
using DatingApp.Core.Domain.Entities;

namespace DatingApp.Core.DTOs;

public class RegisterDTO
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? KnownAs { get; set; }

    [Required]
    public string? Gender { get; set; }
    
    [Required]
    public DateOnly? DateOfBirth { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? Country { get; set; }
    
    [Required]
    [StringLength(15, MinimumLength = 4)]
    public string? Password { get; set;}
}

public static class RegisterDTOExtensions
{
    public static AppUser ToAppUser(this RegisterDTO registerInfo)
    {
        return new AppUser() {
            UserName = registerInfo.Username?.ToLower(),
            KnownAs = registerInfo.KnownAs,
            Gender = registerInfo.Gender,
            DateOfBirth = registerInfo.DateOfBirth,
            City = registerInfo.City,
            Country = registerInfo.Country
            
        };
    }

}