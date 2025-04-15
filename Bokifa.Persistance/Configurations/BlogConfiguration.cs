

namespace Bokifa.Persistance.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.HasOne(x=>x.Author)
                .WithMany(x=>x.Blogs)
                .HasForeignKey(x=>x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.TBlogs)
                .WithOne(x => x.Blog)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
