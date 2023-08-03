namespace DatingApp.Core.DTOs;

public class LoginResponseDTO
{
    public string Username { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
    public string KnownAs { get; set; } = null!;    
}