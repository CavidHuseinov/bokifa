﻿namespace Bokifa.Domain.DTOs.Tag
{
    public record TagDto : BaseDto
    {
        public string Name { get; set; }
        public string PrimaryLanguageType { get; set; }
    }
}
