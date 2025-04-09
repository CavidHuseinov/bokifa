using AutoMapper;
using Bokifa.Domain.DTOs.Banner;
using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.DTOs.BookAndCategory;
using Bokifa.Domain.DTOs.Category;
using Bokifa.Domain.DTOs.HeadBanner;
using Bokifa.Domain.DTOs.TBanner;
using Bokifa.Domain.DTOs.TBook;
using Bokifa.Domain.DTOs.TCategory;
using Bokifa.Domain.DTOs.THeadBanner;
using Bokifa.Domain.Entities;
using Bookifa.Domain.DTOs.Contact;
using Bookifa.Domain.DTOs.FileUpload;
using Bookifa.Domain.DTOs.User;
using Bookifa.Domain.Entities.Identity;

namespace Bookifa.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<LoginDto, AppUser>().ReverseMap();
            CreateMap<ForgotPasswordDto, AppUser>().ReverseMap();
            CreateMap<ResetPasswordDto, AppUser>().ReverseMap();
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<TokenDto, AppUser>().ReverseMap();
            #endregion

            #region FileUpload
            CreateMap<CreateImageUploadDto, string>().ReverseMap();
            CreateMap<CreateFileUploadDto, string>().ReverseMap();
            CreateMap<CreateVideoUploadDto, string>().ReverseMap();
            CreateMap<ImageUploadDto, string>().ReverseMap();
            CreateMap<FileUploadDto, string>().ReverseMap();
            CreateMap<VideoUploadDto, string>().ReverseMap();
            #endregion

            #region Contact
            CreateMap<ContactFormDto, string>().ReverseMap();
            #endregion

            #region HeadBanner
            CreateMap<HeadBannerDto, HeadBanner>().ReverseMap();
            CreateMap<CreateHeadBannerDto, HeadBanner>().ReverseMap();
            CreateMap<UpdateHeadBannerDto, HeadBanner>().ReverseMap();
            #endregion

            #region THeadBanner
            CreateMap<THeadBannerDto, THeadBanner>().ReverseMap();
            CreateMap<CreateTHeadBannerDto, THeadBanner>().ReverseMap();
            CreateMap<UpdateTHeadBannerDto, THeadBanner>().ReverseMap();
            #endregion

            #region Banner
            CreateMap<BannerDto, Banner>().ReverseMap();
            CreateMap<CreateBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();
            #endregion

            #region TBanner
            CreateMap<TBannerDto, TBanner>().ReverseMap();
            CreateMap<CreateTBannerDto, TBanner>().ReverseMap();
            CreateMap<UpdateTBannerDto, TBanner>().ReverseMap();
            #endregion

            #region Category
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            #endregion

            #region TCategory
            CreateMap<TCategoryDto, TCategory>().ReverseMap();
            CreateMap<CreateTCategoryDto, TCategory>().ReverseMap();
            CreateMap<UpdateTCategoryDto, TCategory>().ReverseMap();
            #endregion

            #region Book
            CreateMap<BookDto, Book>().ReverseMap()
                .ForMember(dest => dest.Categories,
                    opt => opt.MapFrom(src => src.BookAndCategories));
            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>().ReverseMap();
            #endregion

            #region BookAndCategory
            CreateMap<BookAndCategoryDto, BookAndCategory>().ReverseMap()
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category))
                .ReverseMap();
            CreateMap<CreateBookAndCategoryDto, BookAndCategory>().ReverseMap();
            #endregion

            #region TBook
            CreateMap<TBookDto, TBook>().ReverseMap();
            CreateMap<CreateTBookDto, TBook>().ReverseMap();
            CreateMap<UpdateTBookDto, TBook>().ReverseMap();
            #endregion

        }
    }
}