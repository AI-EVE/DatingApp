using DatingApp.Core.Domain.Entities;
using DatingApp.Core.DTOs;

namespace DatingApp.Core.ServiceContracts;

public interface IUsersService
{
    Task<IEnumerable<AppUserDTO>> GetUsersAsync();
    Task<AppUserDTO> GetUserByUsernameAsync(string username);    
    Task<AppUser> GetUserAsyncNoDTO(string username);    
    Task<AppUserDTO> GetUserByIdAsync(int Id);
    Task<bool> UpdateUserAsync(string username, AppUserUpdateDTO userUpdateDTO);
    Task<bool> SaveChangesAsync();    
}