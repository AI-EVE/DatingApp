using DatingApp.Core.Domain.Entities;
using DatingApp.Core.Domain.RepositoryContracts;
using DatingApp.Infrastructure.Data;

namespace DatingApp.Infrastructure.Repositories;

public class UsersUpdateRepository : IUsersUpdateRepository
{
    private readonly DataContext _context;

    public UsersUpdateRepository(DataContext context)
    {
        _context = context;
    }
    
    public void UpdateUser(AppUser userToUpdate)
    {
        _context.Attach(userToUpdate);
    }
}