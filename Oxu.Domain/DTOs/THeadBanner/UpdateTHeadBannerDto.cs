using Bokifa.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.DTOs.THeadBanner
{
    public record UpdateTHeadBannerDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public LanguageType LanguageType { get; set; }
    }
}
