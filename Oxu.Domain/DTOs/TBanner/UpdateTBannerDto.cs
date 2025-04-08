using Bokifa.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.DTOs.TBanner
{
    public record UpdateTBannerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BtnName { get; set; }
        public LanguageType LanguageType { get; set; }
        public Guid BannerId { get; set; }
    }
}
