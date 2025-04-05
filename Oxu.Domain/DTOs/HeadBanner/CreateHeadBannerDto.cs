using Oxu.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.DTOs.HeadBanner
{
    public record CreateHeadBannerDto
    {
        public string Content { get; set; }
        public ICollection<Guid> THeadBannerIds { get; set; }
    }
}
