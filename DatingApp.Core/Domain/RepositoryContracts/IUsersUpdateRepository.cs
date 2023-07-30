using DatingApp.Core.Domain.Entities;

namespace DatingApp.Core.Domain.RepositoryContracts;

public interface IUsersUpdateRepository
{
    void UpdateUser(AppUser userToUpdate);    
}