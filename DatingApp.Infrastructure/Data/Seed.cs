using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using DatingApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Data;

public class Seed
{
    public static async Task SeedUsers(DataContext context)
    {
        if(await context.Users?.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("C:\\Users\\hussa\\OneDrive\\Desktop\\DatingApp\\DatingApp.Infrastructure\\Data\\SeedData.json");

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

        users?.ForEach(user => {
            user.UserName = user.UserName?.ToLower();

            var hmac = new HMACSHA512();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("012015ssSS!"));
            user.PasswordSalt = hmac.Key;

            context.Users?.Add(user);

        });

        await context.SaveChangesAsync();
    }
}