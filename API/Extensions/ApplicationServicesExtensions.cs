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

        services.AddCors(options => {
            options.AddDefaultPolicy(builder => {
                builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            });
        });

        services.AddScoped<ITokenGenerator, TokenGenerator>();
    } 
}