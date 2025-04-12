using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bookifa.Domain.Entities.Identity;

namespace Bookifa.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(u => u.UserName)
               .IsUnique();

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.Property(x=>x.UserName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(30).IsRequired();



        }
    }
}
