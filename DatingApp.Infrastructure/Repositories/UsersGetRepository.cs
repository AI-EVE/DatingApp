using DatingApp.Core.Domain.Entities;
using DatingApp.Core.Domain.RepositoryContracts;
using DatingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Repositories;

public class UsersGetRepository : IUsersGetRepository
{
    private readonly DataContext _context;

    public UsersGetRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
        return await _context.Users.AsNoTracking().Include(u => u.Photos).FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.AsNoTracking().Include(u => u.Photos).FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.Users.AsNoTracking().Include(u => u.Photos).ToListAsync();
    }
}