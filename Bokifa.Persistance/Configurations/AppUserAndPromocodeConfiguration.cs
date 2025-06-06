﻿namespace Bokifa.Persistance.Configurations
{
    public class AppUserAndPromocodeConfiguration : IEntityTypeConfiguration<AppUserAndPromocode>
    {
        public void Configure(EntityTypeBuilder<AppUserAndPromocode> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.HasKey(x => new { x.AppUserId, x.PromocodeId });
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.PromocodeId).IsRequired();
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.AppUserAndPromocodes)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Promocode)
                .WithMany(x => x.AppUserAndPromocodes)
                .HasForeignKey(x => x.PromocodeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
