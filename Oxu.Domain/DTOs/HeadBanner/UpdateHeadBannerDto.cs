using Oxu.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.DTOs.HeadBanner
{
    public record UpdateHeadBannerDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
