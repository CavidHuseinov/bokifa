using Bokifa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bokifa.Persistance.Configurations
{
    public class TagConfiguratio : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x=>x.TTags)
                .WithOne(x=>x.Tag)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
