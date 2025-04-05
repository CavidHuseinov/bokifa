﻿using Bokifa.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oxu.Domain.Entities.Identity;
using System.Reflection;

namespace Oxu.Persistance.Context
{
    public sealed class OxuDbContext : IdentityDbContext<AppUser>
    {
        public OxuDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<HeadBanner> HeadBanners { get; set; }
        public DbSet<THeadBanner> THeadBanners { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<TBanner> TBanners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
