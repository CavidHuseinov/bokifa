using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bookifa.Domain.Entities.Identity;
using Bokifa.Persistance;
using Bookifa.Persistance.Context;
using Bokifa.WebAPI.Configurations;

namespace Bookifa.WebAPI.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string sectionName = "Deploy";
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookifaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(sectionName));
            });
            services.AddIdentity<AppUser, IdentityRole>(opt => 
               { 
                 opt.Password.RequireNonAlphanumeric = false; 
                 opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                 opt.Lockout.MaxFailedAccessAttempts = 5; })
                .AddEntityFrameworkStores<BookifaDbContext>().AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
        }
    }
}
