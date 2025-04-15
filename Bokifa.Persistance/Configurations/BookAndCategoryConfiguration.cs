namespace Bokifa.Persistance.Configurations
{
    public class BookAndCategoryConfiguration : IEntityTypeConfiguration<BookAndCategory>
    {
        public void Configure(EntityTypeBuilder<BookAndCategory> builder)
        {
            builder.HasKey(bc => new { bc.BookId, bc.CategoryId });
            builder.HasOne(bc => bc.Book)
                .WithMany(b => b.BookAndCategories)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Category)
                .WithMany(c => c.BookAndCategories)
                .HasForeignKey(bc => bc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
