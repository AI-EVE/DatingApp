using System.Collections.Concurrent;
using DatingApp.Core.Domain.Entities;
using DatingApp.Core.Domain.RepositoryContracts;
using DatingApp.Core.DTOs;
using DatingApp.Core.ServiceContracts;

namespace DatingApp.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUsersGetRepository _usersGetRepository;
    private readonly IUsersUpdateRepository _usersUpdateRepository;
    private readonly ISaveChangesRepository _saveChangesRepository;

    public UsersService(IUsersGetRepository usersGetRepository, IUsersUpdateRepository usersUpdateRepository, ISaveChangesRepository saveChangesRepository)
    {
        _usersGetRepository = usersGetRepository;
        _usersUpdateRepository = usersUpdateRepository;
        _saveChangesRepository = saveChangesRepository;
    }
    
    public async Task<AppUserDTO?> GetUserByIdAsync(int Id)
    {
        var user = await _usersGetRepository.GetUserByIdAsync(Id);
        return user?.ToMemberDTO();
    }

    public async Task<AppUserDTO?> GetUserByUsernameAsync(string username)
    {
        var user = await _usersGetRepository.GetUserByUsernameAsync(username);
        return user?.ToMemberDTO();
    }


    public async Task<AppUser?> GetUserAsyncNoDTO(string username)
    {
        var user = await _usersGetRepository.GetUserByUsernameAsync(username);
        return user;
    }

    

    public async Task<IEnumerable<AppUserDTO>> GetUsersAsync()
    {
        var users = await _usersGetRepository.GetUsersAsync();
        return users.Select(user => user.ToMemberDTO());
    }

    public async Task<bool> UpdateUserAsync(string username, AppUserUpdateDTO userUpdateDTO)
    {
        var userToUpdate = await _usersGetRepository.GetUserByUsernameAsync(username);
        if (userToUpdate == null) return false;

        // Update Logic Here
        userToUpdate.Introduction = userUpdateDTO.Introduction;
        userToUpdate.LookingFor = userUpdateDTO.LookingFor;
        userToUpdate.Interests = userUpdateDTO.Interests;
        userToUpdate.City = userUpdateDTO.City;
        userToUpdate.Country = userUpdateDTO.Country;


        return await _saveChangesRepository.SaveChangesAsync();
    }

    public async Task<bool> SaveChangesAsync() {
        return await _saveChangesRepository.SaveChangesAsync();
    }
}