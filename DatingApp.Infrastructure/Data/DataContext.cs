using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using DatingApp.Core.Domain.Entities;
using DatingApp.Infrastructure.Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Data;

public class DataContext : DbContext
{
    public DbSet<AppUser>? Users { get; set; }
    public DbSet<Photo>? Photos { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AppUserConfig());
        modelBuilder.ApplyConfiguration(new PhotosConfig());




        var userData = File.ReadAllText("C:\\Users\\hussa\\OneDrive\\Desktop\\DatingApp\\DatingApp.Infrastructure\\Data\\SeedData.json");
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
        var UserSeedId = 1;
        var PhotoSeedId = 1;
        users?.ForEach(user => {
            user.UserName = user.UserName?.ToLower();

            var hmac = new HMACSHA512();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("012015ssSS!"));
            user.PasswordSalt = hmac.Key;
            user.Id = UserSeedId++;
            
            List<Photo> Photos = new();
            user.Photos.ForEach(photo => {
                var photoToSeed = new Photo() {
                    Id = PhotoSeedId++,
                    AppUserId = user.Id,
                    Url = photo.Url,
                    IsMain = photo.IsMain
                };  
                Photos.Add(photoToSeed);     
            });

            user.Photos = null;

            modelBuilder.Entity<AppUser>().HasData(user);
            modelBuilder.Entity<Photo>().HasData(Photos);         
        });
    }
}
