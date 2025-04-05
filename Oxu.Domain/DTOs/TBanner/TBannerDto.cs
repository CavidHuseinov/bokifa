﻿using Bokifa.Domain.Enums;
using Oxu.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.TBanner
{
    public record TBannerDto:BaseDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BtnName { get; set; }
        public LanguageType LanguageType { get; set; }
    }
}
