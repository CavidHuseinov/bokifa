﻿
namespace Bokifa.Domain.DTOs.TBlog
{
    public record UpdateTBlogDto
    {
        public Guid Id { get; set; }
        public LanguageType LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid BookId { get; set; }
    }
}
