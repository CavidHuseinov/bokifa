using Bokifa.Application.Seeds;
using Bokifa.Persistance;
using Bokifa.WebAPI.Configurations;
using Bookifa.Domain.Entities.Identity;
using Bookifa.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bookifa.WebAPI.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string sectionName = "Default";
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BokifaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(sectionName));
            });
            services.AddIdentity<AppUser, IdentityRole>(opt => 
               { 
                 opt.Password.RequireNonAlphanumeric = false; 
                 opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                 opt.Lockout.MaxFailedAccessAttempts = 5; })
                .AddEntityFrameworkStores<BokifaDbContext>().AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(AssemblyReference).Assembly);


        }
        public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await DataSeeder.SeedRolesAsync(roleManager);
        }
        public static async Task CurrencyDatabaseAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await DataSeeder.SeedRolesAsync(roleManager);

            var dbContext = scope.ServiceProvider.GetRequiredService<BokifaDbContext>();
            var currencySeeder = new CurrencySeeder(dbContext);
            await currencySeeder.SeedCurrenciesAsync();
        }

    }
}
