namespace Bokifa.Persistance.Configurations
{
    public class HeadBannerConfiguration : IEntityTypeConfiguration<HeadBanner>
    {
        public void Configure(EntityTypeBuilder<HeadBanner> builder)
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
            builder.HasMany(x=>x.THeadBanners)
                .WithOne(x => x.HeadBanner)
                .HasForeignKey(x => x.HeadBannerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
