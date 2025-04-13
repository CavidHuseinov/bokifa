using Bokifa.Domain.Enums;
using Bookifa.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.Entities
{
    public class HeadBanner:BaseEntity
    {
        public string Content { get; set; }
        public PrimaryLanguageType LanguageType { get; set; } = PrimaryLanguageType.Eng;
        public ICollection<THeadBanner>? THeadBanners { get; set; }
    }
}
