using DatingApp.Core.Domain.RepositoryContracts;
using DatingApp.Infrastructure.Data;

namespace DatingApp.Infrastructure.Repositories;

public class SaveChangesRepository : ISaveChangesRepository
{
    private readonly DataContext _context;
    public SaveChangesRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}