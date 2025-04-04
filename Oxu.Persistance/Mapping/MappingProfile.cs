﻿using AutoMapper;
using Bokifa.Domain.DTOs.HeadBanner;
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
        }
    }
}
