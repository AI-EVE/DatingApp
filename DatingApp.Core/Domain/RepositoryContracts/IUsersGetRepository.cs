using DatingApp.Core.Domain.Entities;

namespace DatingApp.Core.Domain.RepositoryContracts;

public interface IUsersGetRepository
{
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<AppUser?> GetUserByIdAsync(int id);
}