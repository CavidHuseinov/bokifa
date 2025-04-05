using Oxu.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.DTOs.THeadBanner
{
    public record THeadBannerDto:BaseDto
    {
        public string Content { get; set; }
        public string LanguageType { get; set; }
    }
}
