namespace Bokifa.Persistance.Configurations
{
    public class TTagConfiguration : IEntityTypeConfiguration<TTag>
    {
        public void Configure(EntityTypeBuilder<TTag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                .HasColumnName("CreatedAt")
                .IsRequired();
            });
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
