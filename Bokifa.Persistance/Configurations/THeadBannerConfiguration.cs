namespace Bokifa.Persistance.Configurations
{
    public class THeadBannerConfiguration : IEntityTypeConfiguration<THeadBanner>
    {
        public void Configure(EntityTypeBuilder<THeadBanner> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.Property(x => x.Content)
                .IsRequired();
        }
    }
}
