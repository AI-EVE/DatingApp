namespace DatingApp.Core.Domain.RepositoryContracts;

public interface ISaveChangesRepository
{
    Task<bool> SaveChangesAsync();   
}