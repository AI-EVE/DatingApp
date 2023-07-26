using DatingApp.Core.Domain.Entities;
using DatingApp.Core.DTOs;

namespace DatingApp.Core.Domain.RepositoryContracts
{
    public interface IUsersRepository
    {
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser> GetUserByIdAsync(int id);
    Task<AppUser> GetUserByUsernameAsync(string username);
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<MemberDTO> GetMemberAsync(string username);
    Task<IEnumerable<MemberDTO>> GetMembersAsync();
    }
}