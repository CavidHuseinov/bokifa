

namespace Bokifa.Persistance.Configurations
{
    public class PromocodeConfiguration : IEntityTypeConfiguration<Promocode>
    {
        public void Configure(EntityTypeBuilder<Promocode> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.Property(x => x.Code)
                .IsRequired();
            builder.Property(x => x.Discount)
                .IsRequired();
            builder.Property(x => x.ExpirationDate)
                .IsRequired();

        }
    }
}
