namespace Bokifa.Persistance.Configurations
{
    public class TBannerConfiguration : IEntityTypeConfiguration<TBanner>
    {
        public void Configure(EntityTypeBuilder<TBanner> builder)
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
