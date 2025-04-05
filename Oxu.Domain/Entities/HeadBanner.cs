using Bokifa.Domain.Enums;
using Oxu.Domain.Abstractions;
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
        public LanguageType LanguageType { get; set; } = LanguageType.Azerbaijan;
        public ICollection<THeadBanner>? THeadBanners { get; set; }
    }
}
