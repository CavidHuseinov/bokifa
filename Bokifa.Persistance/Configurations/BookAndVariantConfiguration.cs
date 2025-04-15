namespace Bokifa.Persistance.Configurations
{
    public class BookAndVariantConfiguration : IEntityTypeConfiguration<BookAndVariant>
    {
        public void Configure(EntityTypeBuilder<BookAndVariant> builder)
        {
            builder.HasKey(x => new { x.BookId, x.VariantId });
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookAndVariants)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Variant)
                .WithMany(x => x.BookAndVariants)
                .HasForeignKey(x => x.VariantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
