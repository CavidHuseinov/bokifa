﻿using Bokifa.Domain.DTOs.Category;

namespace Bokifa.Domain.DTOs.TCategory
{
    public record TCategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string LanguageType { get; set; }
        public CategoryDto Category { get; set; }
    }
}
