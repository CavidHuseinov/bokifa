﻿
namespace Bokifa.Domain.DTOs.Blog
{
    public record UpdateBlogDto
    {
        public Guid Id { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Guid>? TagIds { get; set; }
    }
}
