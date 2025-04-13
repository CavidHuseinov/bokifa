using Bokifa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bokifa.Persistance.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.HasKey(xd => new { xd.AppUserId, xd.BookId });
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Favorites)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Favorites)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
