namespace Bokifa.Persistance.Configurations
{
    public class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.HasMany(x=>x.TBanners)
                .WithOne(x => x.Banner)
                .HasForeignKey(x => x.BannerId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
