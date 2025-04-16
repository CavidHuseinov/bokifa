

namespace Bokifa.Persistance.Configurations
{
    public class ContactAddressConfiguration : IEntityTypeConfiguration<ContactAddress>
    {
        public void Configure(EntityTypeBuilder<ContactAddress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.Property(x => x.PhoneNumber).IsRequired();

            builder.HasOne(x=>x.AppUser)
                .WithOne(x => x.ContactAddress)
                .HasForeignKey<ContactAddress>(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
