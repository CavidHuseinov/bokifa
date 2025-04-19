

namespace Bokifa.Persistance.Configurations
{
    public class ShippingInfoConfiguration : IEntityTypeConfiguration<ShippingInfo>
    {
        public void Configure(EntityTypeBuilder<ShippingInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Apartment).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.PostalCode).IsRequired();

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.ShippingInfos)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
