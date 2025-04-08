using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.DTOs.Banner
{
    public record UpdateBannerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BtnName { get; set; }
        public string ImgUrl { get; set; }
        public decimal? Discount { get; set; }
    }
}
