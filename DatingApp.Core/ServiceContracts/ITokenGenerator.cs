using DatingApp.Core.Domain.Entities;

namespace DatingApp.Core.ServiceContracts;

public interface ITokenGenerator
{
    string GenerateToken(AppUser user);
}