using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oxu.Domain.Entities.Identity;
using Oxu.Persistance;
using Oxu.Persistance.Context;

namespace Oxu.WebAPI.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string sectionName = "Default";
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OxuDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(sectionName));
            });
            services.AddIdentity<AppUser, IdentityRole>(opt => 
               { 
                 opt.Password.RequireNonAlphanumeric = false; 
                 opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                 opt.Lockout.MaxFailedAccessAttempts = 5; })
                .AddEntityFrameworkStores<OxuDbContext>().AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
        }
    }
}
