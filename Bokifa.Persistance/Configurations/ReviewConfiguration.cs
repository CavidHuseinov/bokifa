namespace Bokifa.Persistance.Configurations 
{
    public class ReviewConfiguration:IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.Property(x => x.Rating).IsRequired();
            builder.Property(x => x.Comment).IsRequired(false);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
