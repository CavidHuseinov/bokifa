

namespace Bokifa.Persistance.Configurations
{
    public class BlogAndTagConfiguration : IEntityTypeConfiguration<BlogAndTag>
    {
        public void Configure(EntityTypeBuilder<BlogAndTag> builder)
        {
            builder.HasKey(x => new { x.BlogId, x.TagId });
            builder.HasOne(x => x.Blog)
                .WithMany(x => x.BlogAndTags)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Tag)
                .WithMany(x => x.BlogAndTags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
