
using Bokifa.Application.IServices;
using Bokifa.Domain.IRepositories;
using Bokifa.Persistance.Repositories;
using Bokifa.Persistance.Services;
using Oxu.Application.IService;
using Oxu.Application.IServices;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.Repositories.Generics;
using Oxu.Persistance.Services;
using Oxu.Persistance.UnitOfWorks;

namespace Oxu.WebAPI.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWorks>();
            #endregion

            #region Repositories
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddScoped<IHeadBannerRepo, HeadBannerRepo>();
            services.AddScoped<ITHeadBannerRepo, THeadBannerRepo>();
            #endregion

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IHeadBannerService, HeadBannerService>();
            services.AddScoped<ITHeadBannerService, THeadBannerService>();
            #endregion

        }
    }
}
