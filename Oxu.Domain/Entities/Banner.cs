using Bokifa.Domain.Enums;
using Oxu.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.Entities
{
    public class Banner:BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Decimal? Discount { get; set; }
        public string BtnName { get; set; }
        public string ImgUrl { get; set; }
        public LanguageType PrimaryLanguageType { get; set; }= LanguageType.Azerbaijan;
        public ICollection<TBanner>? TBanners { get; set; }
    }
}
