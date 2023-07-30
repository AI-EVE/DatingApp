using DatingApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingApp.Infrastructure.Data.EntitiesConfigurations;

public class PhotosConfig : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasOne(p => p.AppUser)
            .WithMany(u => u.Photos)
            .HasForeignKey(p => p.AppUserId);
    }
}