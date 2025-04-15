using AutoMapper;
using Bokifa.Domain.DTOs.Author;
using Bokifa.Domain.DTOs.Banner;
using Bokifa.Domain.DTOs.Blog;
using Bokifa.Domain.DTOs.BlogAndTag;
using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.DTOs.BookAndCategory;
using Bokifa.Domain.DTOs.BookAndTag;
using Bokifa.Domain.DTOs.BookAndVariant;
using Bokifa.Domain.DTOs.CartItem;
using Bokifa.Domain.DTOs.Category;
using Bokifa.Domain.DTOs.ContactAdress;
using Bokifa.Domain.DTOs.Favorite;
using Bokifa.Domain.DTOs.HeadBanner;
using Bokifa.Domain.DTOs.Review;
using Bokifa.Domain.DTOs.Tag;
using Bokifa.Domain.DTOs.TBanner;
using Bokifa.Domain.DTOs.TBlog;
using Bokifa.Domain.DTOs.TBook;
using Bokifa.Domain.DTOs.TCategory;
using Bokifa.Domain.DTOs.THeadBanner;
using Bokifa.Domain.DTOs.TTag;
using Bokifa.Domain.DTOs.TVariant;
using Bokifa.Domain.DTOs.Variant;
using Bookifa.Domain.DTOs.Contact;
using Bookifa.Domain.DTOs.FileUpload;
using Bookifa.Domain.DTOs.User;

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
            CreateMap<BookMiniDto, Book>().ReverseMap().ReverseMap();
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

            #region Tag
            CreateMap<TagDto, Tag>().ReverseMap();
            CreateMap<CreateTagDto, Tag>().ReverseMap();
            CreateMap<UpdateTagDto, Tag>().ReverseMap();
            #endregion

            #region TTag
            CreateMap<TTagDto, TTag>().ReverseMap();
            CreateMap<CreateTTagDto, TTag>().ReverseMap();
            CreateMap<UpdateTTagDto, TTag>().ReverseMap();
            #endregion

            #region BookAndTag
            CreateMap<BookAndTagDto, BookAndTag>().ReverseMap();
            CreateMap<CreateBookAndTagDto, BookAndTag>().ReverseMap();
            #endregion

            #region Review
            CreateMap<ReviewDto, Review>().ReverseMap();
            CreateMap<CreateReviewDto, Review>().ReverseMap();
            #endregion

            #region Variant
            CreateMap<VariantDto, Variant>().ReverseMap();
            CreateMap<CreateVariantDto, Variant>().ReverseMap();
            CreateMap<UpdateVariantDto, Variant>().ReverseMap();
            #endregion

            #region TVariant
            CreateMap<TVariantDto, TVariant>().ReverseMap();
            CreateMap<CreateTVariantDto, TVariant>().ReverseMap();
            CreateMap<UpdateTVariantDto, TVariant>().ReverseMap();
            #endregion

            #region BookAndVariant
            CreateMap<BookAndVariantDto, BookAndVariant>().ReverseMap();
            CreateMap<CreateBookAndVariantDto, BookAndVariant>().ReverseMap();
            #endregion

            #region Favorite
            CreateMap<FavoriteDto, Favorite>().ReverseMap();
            CreateMap<CreateFavoriteDto, Favorite>().ReverseMap();
            #endregion

            #region CartItem
            CreateMap<CartItemDto, CartItem>().ReverseMap();
            CreateMap<CreateCartItemDto, CartItem>().ReverseMap();
            #endregion

            #region ContactAdress
            CreateMap<ContactAddressDto, AppUser>().ReverseMap();
            CreateMap<CreateContactAddressDto, string>().ReverseMap();
            #endregion

            #region Author
            CreateMap<CreateAuthorDto, Author>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
            #endregion

            #region Blog
            CreateMap<BlogDto, Blog>().ReverseMap();
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            #endregion

            #region TBlog
            CreateMap<TBlogDto, TBlog>().ReverseMap();
            CreateMap<CreateTBlogDto, TBlog>().ReverseMap();
            CreateMap<UpdateTBlogDto, TBlog>().ReverseMap();
            #endregion

            #region BlogAndTag
            CreateMap<BlogAndTagDto, BlogAndTag>().ReverseMap();
            CreateMap<CreateBlogAndTagDto, BlogAndTag>().ReverseMap();
            #endregion
        }
    }
}