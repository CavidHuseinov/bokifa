using Bokifa.Domain.Enums;
using Bookifa.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.Entities
{
    public class TBanner:BaseEntity
    {
        public LanguageType LanguageType { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BtnName { get; set; }
        public Banner Banner { get; set; }
        public Guid BannerId { get; set; }
    }
}
