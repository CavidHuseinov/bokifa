using AutoMapper;
using Bokifa.Domain.DTOs.Banner;
using Bokifa.Domain.DTOs.HeadBanner;
using Bokifa.Domain.DTOs.TBanner;
using Bokifa.Domain.DTOs.THeadBanner;
using Bokifa.Domain.Entities;
using Oxu.Domain.DTOs.Contact;
using Oxu.Domain.DTOs.FileUpload;
using Oxu.Domain.DTOs.User;
using Oxu.Domain.Entities.Identity;

namespace Oxu.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<RegisterDto,AppUser>().ReverseMap();
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
            CreateMap<HeadBannerDto,HeadBanner>().ReverseMap();
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
        }
    }
}
