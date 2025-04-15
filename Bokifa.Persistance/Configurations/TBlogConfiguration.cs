

namespace Bokifa.Persistance.Configurations
{
    public class TBlogConfiguration : IEntityTypeConfiguration<TBlog>
    {
        public void Configure(EntityTypeBuilder<TBlog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });

        }
    }
}
