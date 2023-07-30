using DatingApp.Core.Domain.RepositoryContracts;
using DatingApp.Core.ServiceContracts;
using DatingApp.Core.Services;
using DatingApp.Infrastructure.Data;
using DatingApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace API.Extensions;

public static class ApplicationServicesExtensions
{
   public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
   {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUsersService, UsersService>();

        services.AddScoped<IUsersGetRepository, UsersGetRepository>();

        services.AddScoped<IUsersUpdateRepository, UsersUpdateRepository>();

        services.AddScoped<ISaveChangesRepository, SaveChangesRepository>();

        services.AddScoped<ITokenGenerator, TokenGenerator>();
    } 
}