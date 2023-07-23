using DatingApp.Core.ServiceContracts;
using DatingApp.Core.Services;
using DatingApp.Infrastructure.Data;
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

        services.AddCors();

        services.AddScoped<ITokenGenerator, TokenGenerator>();
    } 
}