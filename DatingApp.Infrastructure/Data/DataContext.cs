using DatingApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Data;

public class DataContext : DbContext
{
    public DbSet<AppUser>? Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}
