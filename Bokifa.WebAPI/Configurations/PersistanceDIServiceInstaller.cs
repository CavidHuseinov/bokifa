
using Bokifa.Application.IServices;
using Bokifa.Domain.IRepositories;
using Bokifa.Persistance.Repositories;
using Bokifa.Persistance.Services;
using Bokifa.WebAPI.Configurations;
using Bookifa.Application.IService;
using Bookifa.Application.IServices;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.Repositories.Generics;
using Bookifa.Persistance.Services;
using Bookifa.Persistance.UnitOfWorks;

namespace Bookifa.WebAPI.Configurations
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
            services.AddScoped<IBannerRepo, BannerRepo>();
            services.AddScoped<ITBannerRepo, TBannerRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ITCategoryRepo, TCategoryRepo>();
            services.AddScoped<IBookRepo, BookRepo>();
            services.AddScoped<ITBookRepo, TBookRepo>();
            services.AddScoped<ITagRepo, TagRepo>();
            services.AddScoped<ITTagRepo, TTagRepo>();
            services.AddScoped<IReviewRepo, ReviewRepo>();
            services.AddScoped<IVariantRepo, VariantRepo>();
            services.AddScoped<ITVariantRepo, TVariantRepo>();
            services.AddScoped<IFavoriteRepo, FavoriteRepo>();
            services.AddScoped<ICartItemRepo, CartItemRepo>();
            services.AddScoped<IAuthorRepo, AuthorRepo>();
            services.AddScoped<IBlogRepo, BlogRepo>();
            services.AddScoped<ITBlogRepo, TBlogRepo>();
            #endregion

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IHeadBannerService, HeadBannerService>();
            services.AddScoped<ITHeadBannerService, THeadBannerService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<ITBannerService, TBannerService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITCategoryService, TCategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ITBookService, TBookService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITTagService, TTagService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IVariantService, VariantService>();
            services.AddScoped<ITVariantService, TVariantService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IContactAddressService, ContactAddressService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ITBlogService, TBlogService>();
            #endregion

        }
    }
}
