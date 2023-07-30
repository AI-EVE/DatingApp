using DatingApp.Core.Domain.Entities;
using DatingApp.Core.Domain.RepositoryContracts;
using DatingApp.Core.DTOs;
using DatingApp.Core.ServiceContracts;

namespace DatingApp.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUsersGetRepository _usersGetRepository;
    private readonly IUsersUpdateRepository _usersUpdateRepository;
    private readonly ISaveChangesRepository _usersDeleteRepository;

    public UsersService(IUsersGetRepository usersGetRepository, IUsersUpdateRepository usersUpdateRepository, ISaveChangesRepository usersDeleteRepository)
    {
        _usersGetRepository = usersGetRepository;
        _usersUpdateRepository = usersUpdateRepository;
        _usersDeleteRepository = usersDeleteRepository;
    }
    
    public async Task<AppUserDTO> GetUserByIdAsync(int Id)
    {
        var user = await _usersGetRepository.GetUserByIdAsync(Id);
        return user.ToMemberDTO();
    }

    public async Task<AppUserDTO> GetUserByUsernameAsync(string username)
    {
        var user = await _usersGetRepository.GetUserByUsernameAsync(username);
        return user.ToMemberDTO();
    }

    public async Task<IEnumerable<AppUserDTO>> GetUsersAsync()
    {
        var users = await _usersGetRepository.GetUsersAsync();
        return users.Select(user => user.ToMemberDTO());
    }

    public async Task<bool> UpdateUserAsync(int Id)
    {
        var userToUpdate = await _usersGetRepository.GetUserByIdAsync(Id);
        if (userToUpdate == null) return false;

        // Update Logic Here

        _usersUpdateRepository.UpdateUser(userToUpdate);
        return await _usersDeleteRepository.SaveChangesAsync();
    }
}