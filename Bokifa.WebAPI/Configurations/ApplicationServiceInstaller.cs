using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Bokifa.Application;
using Bokifa.Application.Seeds;
using Bokifa.WebAPI.Configurations;

namespace Bookifa.WebAPI.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        }

        public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await DataSeeder.SeedRolesAsync(roleManager);
        }
    }
}
