namespace Bokifa.Persistance.Configurations
{
    public class TCategoryConfiguration : IEntityTypeConfiguration<TCategory>
    {
        public void Configure(EntityTypeBuilder<TCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
