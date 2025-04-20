namespace Bokifa.Persistance.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.HasKey(ci => new { ci.AppUserId, ci.BookId });
            builder
                .HasOne(ci => ci.AppUser)
                .WithMany(u => u.CartItems)
                .HasForeignKey(ci => ci.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(ci => ci.Book)
                .WithMany(b => b.CartItems)
                .HasForeignKey(ci => ci.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Promocode)
                .WithMany()
                .HasForeignKey(x => x.PromocodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
