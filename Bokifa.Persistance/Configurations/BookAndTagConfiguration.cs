namespace Bokifa.Persistance.Configurations
{
    public class BookAndTagConfiguration:IEntityTypeConfiguration<BookAndTag>
    {
        public void Configure(EntityTypeBuilder<BookAndTag> builder)
        {
            builder.HasKey(x => new { x.BookId, x.TagId });
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookAndTags)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Tag)
                .WithMany(x => x.BookAndTags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
